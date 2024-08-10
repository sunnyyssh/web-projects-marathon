using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksLibrary.Database.BookFiles.Migrations
{
    /// <inheritdoc />
    public partial class AddMimeTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "BookFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "BookFiles");
        }
    }
}
