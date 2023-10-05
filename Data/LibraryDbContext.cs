using BookEntitie = Domain.Book.Entities;
using UserEntitie = Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Data.Book.Mapping;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<BookEntitie.Book> Books { get; set; }
        public DbSet<UserEntitie.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapping());
        }
    }
}
