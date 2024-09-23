


using BookServicesApi.Data;
using BookServicesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookServicesApi.Services {
    public class BookService {
        private readonly BookWebApiContext _context;
        private readonly AuthorService _authorService;

        public BookService(BookWebApiContext context, AuthorService authorService) {
            _context = context;
            _authorService = authorService;
        }

        public async Task<List<Book>> GetAllBooksAsync() {
            return await _context.Books
            .Include(b => b.Author)
            .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id) {
            return await _context.Books
            .Include(b => b.Author) 
            .FirstOrDefaultAsync(b => b.Id == id);
        }
                      
        public async Task UpdateBookAsync(Book books) {
            _context.Entry(books).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddBookAsync(Book books) {
            if (!_authorService.AuthorsExist(books.AuthorId)) {
                throw new Exception("Author does not exist");
            }
            _context.Books.Add(books);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id) {
            var book = await _context.Books.FindAsync(id);
            if (book != null) {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public bool BooksExist(int id) {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}