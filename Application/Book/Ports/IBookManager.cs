using Application.Book.Requests;
using Application.Book.Responses;

namespace Application.Book.Ports
{
    public interface IBookManager
    {
        Task<BookResponse> CreateAsync(CreateBookRequest book);
        BookResponse UpdateBook(UpdateBookRequest book);
        Task DeleteBookAsync(int id);
        Task<BookResponse> GetBookByIdAsync(int id);
        Task<BookResponse> GetBooksAsync();
    }
}
