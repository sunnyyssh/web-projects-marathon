using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityInfo.Migrations
{
    /// <inheritdoc />
    public partial class MusicAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteSongId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MusicInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteSongId",
                table: "AspNetUsers",
                column: "FavouriteSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MusicInfo_FavouriteSongId",
                table: "AspNetUsers",
                column: "FavouriteSongId",
                principalTable: "MusicInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MusicInfo_FavouriteSongId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MusicInfo");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavouriteSongId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavouriteSongId",
                table: "AspNetUsers");
        }
    }
}
