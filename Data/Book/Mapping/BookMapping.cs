using Microsoft.EntityFrameworkCore;
using Entity = Domain.Book.Entities;

namespace Data.Book.Mapping
{
    public class BookMapping : IEntityTypeConfiguration<Entity.Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entity.Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Bio)
                .IsRequired()
                .HasColumnName("Bio")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(3000);

            builder.Property(x => x.Pages)
                .IsRequired()
                .HasColumnName("Pages")
                .HasColumnType("INTEGER");

            builder.Property(x => x.Author)
                .IsRequired()
                .HasColumnName("Author")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Edition)
                .IsRequired()
                .HasColumnName("Edition")
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.PublishingCompany)
                .IsRequired()
                .HasColumnName("PublishCompany")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.HasIndex(e => e.Id, "IDX_BOOK_ID");
            builder.HasIndex(e => e.Author, "IDX_BOOK_AUTHOR");
            builder.HasIndex(e => e.Name, "IDX_BOOK_NAME");
        }
    }
}
