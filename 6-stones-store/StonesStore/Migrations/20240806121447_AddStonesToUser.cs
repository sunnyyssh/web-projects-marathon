using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StonesStore.Migrations
{
    /// <inheritdoc />
    public partial class AddStonesToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoneType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    ConsumerIdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stone_AspNetUsers_ConsumerIdentityUserId",
                        column: x => x.ConsumerIdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stone_StoneType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "StoneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stone_ConsumerIdentityUserId",
                table: "Stone",
                column: "ConsumerIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stone_TypeId",
                table: "Stone",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stone");

            migrationBuilder.DropTable(
                name: "StoneType");
        }
    }
}
