using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class AddTake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takes",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    WorkTime = table.Column<double>(type: "double", nullable: false),
                    AbsentNum = table.Column<int>(type: "int", nullable: false),
                    AbsentTime = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takes", x => new { x.WorkId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_Takes_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Takes_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Takes_StudentId",
                table: "Takes",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Takes");
        }
    }
}
