using Application.Book.Dto;

namespace Application.Book.Requests
{
    public class UpdateBookRequest
    {
        public int Id;
        public BookDto? Data;
    }
}
