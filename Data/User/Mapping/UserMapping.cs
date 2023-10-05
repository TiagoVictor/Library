using Domain.Role.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = Domain.User.Entities;

namespace Data.User.Mapping;

public class UserMapping : IEntityTypeConfiguration<Entity.User>
{
    public void Configure(EntityTypeBuilder<Entity.User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

        builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

        builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

        builder.HasIndex(x => x.Id, "IDX_USER_ID");
        builder.HasIndex(x => x.Email, "IDX_USER_EMAIL").IsUnique();

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string,object>>(
                "UserRole",
                role => role
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey("RoleId")
                .HasConstraintName("FK_UserRole_RoleId")
                .OnDelete(DeleteBehavior.Cascade),
                user => user
                .HasOne<Entity.User>()
                .WithMany()
                .HasForeignKey("UserId")
                .HasConstraintName("FK_UserRole_UserId")
                .OnDelete(DeleteBehavior.Cascade)
            );
    }
}
