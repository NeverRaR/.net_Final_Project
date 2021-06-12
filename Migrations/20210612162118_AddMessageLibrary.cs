using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class AddMessageLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageLibraries",
                columns: table => new
                {
                    MessageLibraryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceiverUserId = table.Column<int>(type: "int", nullable: true),
                    SenderUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLibraries", x => x.MessageLibraryId);
                    table.ForeignKey(
                        name: "FK_MessageLibraries_Users_ReceiverUserId",
                        column: x => x.ReceiverUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageLibraries_Users_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLibraries_ReceiverUserId",
                table: "MessageLibraries",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLibraries_SenderUserId",
                table: "MessageLibraries",
                column: "SenderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageLibraries");
        }
    }
}
