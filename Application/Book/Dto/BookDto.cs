using Entity = Domain.Book.Entities;

namespace Application.Book.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Edition { get; set; }
        public string PublishingCompany { get; set; } = string.Empty;

        public static Entity.Book MapToEntity(BookDto dto)
        {
            return new Entity.Book
            {
                Id = dto.Id,
                Name = dto.Name,
                Bio = dto.Bio,
                Author = dto.Author,
                Pages = dto.Pages,
                Edition = dto.Edition,
                PublishingCompany = dto.PublishingCompany
            };
        }

        public static BookDto MapToDto(Entity.Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Bio = book.Bio,
                Author = book.Author,
                Pages = book.Pages,
                Edition = book.Edition,
                PublishingCompany = book.PublishingCompany
            };
        }
    }
}