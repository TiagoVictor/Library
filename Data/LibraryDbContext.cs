using Entities =  Domain.Book.Entities;
using Microsoft.EntityFrameworkCore;
using Data.Book.Mapping;

namespace Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Entities.Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapping());
        }
    }
}
