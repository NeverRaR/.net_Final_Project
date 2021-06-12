using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class AddAnnouncementSend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "sendTime",
                table: "Announcement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AnnouncementSend",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementSend", x => new { x.AnnouncementId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_AnnouncementSend_Announcement_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcement",
                        principalColumn: "AnnouncementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementSend_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementSend_ReceiverId",
                table: "AnnouncementSend",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementSend");

            migrationBuilder.DropColumn(
                name: "sendTime",
                table: "Announcement");
        }
    }
}
