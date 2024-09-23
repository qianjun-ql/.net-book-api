using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookServicesApi.Models;
using BookServicesApi.Services;

namespace BookServicesApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase {
        private readonly BookService _bookService;

        public BookController(BookService bookService) {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() {
            return await _bookService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id) {
            var books = await _bookService.GetBookByIdAsync(id);

            if (books == null) {
                return NotFound();
            }

            return books;
        }

        [HttpPut("{id}")] 
            public async Task<ActionResult<Book>> PutBooks(int id, Book books) {
                if (id != books.Id) {
                    return BadRequest();
                }

                try {
                    await _bookService.UpdateBookAsync(books);
                } catch {
                    if (!_bookService.BooksExist(id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return NoContent();
            }

            [HttpPost]
            public async Task<ActionResult<Book>> PostBooks(Book books) {
                try {
                    if (!ModelState.IsValid) {
                        return BadRequest(ModelState);
                    }
                    await _bookService.AddBookAsync(books);
                    return CreatedAtAction("GetBooks", new {id = books.Id, books});
                } catch (Exception ex) {
                    if (ex.Message == "Author does not exist") {
                        return BadRequest("Author does not exist, failed to create book.");
                    }

                    Console.WriteLine(ex.Message);
                    return StatusCode(500, "Internal server error");
                }
            }

            [HttpDelete] 
            public async Task<ActionResult<Book>> DeleteBooks(int id) {
                var books = await _bookService.GetBookByIdAsync(id);

                if (books == null) {
                    return NotFound();
                }

                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }



        }


    }
