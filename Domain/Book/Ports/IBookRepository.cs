namespace Domain.Book.Ports
{
    public interface IBookRepository
    {
        Task<int> CreateAsync(Entities.Book book);
        Task<Entities.Book> UpdateBook(Entities.Book book);
        Task DeleteBookAsync(Entities.Book book);
        Task<Entities.Book> GetBookByIdAsync(int id);
        Task<List<Entities.Book>> GetBooksAsync();
    }
}
