using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class ChangeResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Resumes_ResumeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ResumeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_StudentId",
                table: "Resumes",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Users_StudentId",
                table: "Resumes",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Users_StudentId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_StudentId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Resumes");

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ResumeId",
                table: "Users",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Resumes_ResumeId",
                table: "Users",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
