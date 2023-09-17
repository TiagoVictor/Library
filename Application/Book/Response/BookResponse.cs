using Application.Book.Dto;

namespace Application.Book.Responses
{
    public class BookResponse : Response
    {
        public BookDto? Data;
        public List<BookDto> Books = new();
    }
}
