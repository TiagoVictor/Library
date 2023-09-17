using Domain.Book.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Domain.Book.Entities.Book book)
        {
            await _context
                .Books
                .AddAsync(book);

            await _context
                .SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteBookAsync(Domain.Book.Entities.Book book)
        {
            _context
                .Books
                .Remove(book);

            await _context
                .SaveChangesAsync();
        }

        public async Task<Domain.Book.Entities.Book> GetBookByIdAsync(int id)
        {
            return await _context
                .Books
                .FirstOrDefaultAsync(x => x.Id == id) ?? new();
        }

        public async Task<List<Domain.Book.Entities.Book>> GetBooksAsync()
        {
            return await _context
                .Books
                .ToListAsync();
        }

        public async Task<Domain.Book.Entities.Book> UpdateBook(Domain.Book.Entities.Book book)
        {
            _context
               .Books
               .Update(book);

            await _context
                .SaveChangesAsync();

            return book;
        }
    }
}
