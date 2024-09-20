


using BookServicesApi.Data;
using BookServicesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookServicesApi.Services {
    public class BookService {
        private readonly BookWebApiContext _context;

        public BookService(BookWebApiContext context) {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync() {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> getBookByIdAsync(int id) {
            return await _context.Books.FindAsync(id);
        }

        public async Task UpdateBookAsync(Book books) {
            _context.Entry(books).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddBookAsync(Book books) {
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