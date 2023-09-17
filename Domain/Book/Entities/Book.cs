using Domain.Book.Exceptions;
using Domain.Book.Ports;

namespace Domain.Book.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int Pages { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Edition { get; set; }
        public string PublishingCompany { get; set; } = string.Empty;

        private void ValidateState()
        {
            if (string.IsNullOrEmpty(Name))
                throw new InvalidNameException();

            if (string.IsNullOrEmpty(Bio))
                throw new InvalidBioException();

            if (string.IsNullOrEmpty(Author))
                throw new InvalidAuthorException();

            if (string.IsNullOrEmpty(PublishingCompany))
                throw new InvalidPublishingCompanyException();

            if (Pages <= 0)
                throw new InvalidPagesException();

            if (Edition <= 0)
                throw new InvalidEditionException();
        }

        public async Task Save(IBookRepository repository)
        {
            ValidateState();

            if (Id == 0)
                Id = await repository.CreateAsync(this);
        }
    }
}
