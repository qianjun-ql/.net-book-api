using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookServicesApi.Models;
using BookServicesApi.Services;

namespace BookServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _authorService.GetAllAuthorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var authors = await _authorService.GetAuthorByIdAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAuthors(int id, Author authors)
        {
            if (id != authors.Id)
            {
                return BadRequest();
            }

            try
            {
                await _authorService.UpdateAuthorAsync(authors);
            }
            catch
            {
                if (!_authorService.AuthorsExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    [HttpPost]
    public async Task<ActionResult<Author>> PostAuthors(Author authors)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _authorService.AddAuthorAsync(authors);
            return CreatedAtAction("GetAuthors", new { id = authors.Id }, authors);
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
    
        [HttpDelete("{id}")]
        public async Task<ActionResult<Author>> DeleteAuthors(int id)
        {
            var authors = await _authorService.GetAuthorByIdAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
