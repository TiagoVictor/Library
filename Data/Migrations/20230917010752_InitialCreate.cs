using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Bio = table.Column<string>(type: "NVARCHAR(3000)", maxLength: 3000, nullable: false),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Edition = table.Column<string>(type: "NVARCHAR(64)", nullable: false),
                    PublishCompany = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_BOOK_AUTHOR",
                table: "Book",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IDX_BOOK_ID",
                table: "Book",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IDX_BOOK_NAME",
                table: "Book",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
