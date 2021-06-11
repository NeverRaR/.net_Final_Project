using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class ChangeApply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apply_Resumes_ResumeId",
                table: "Apply");

            migrationBuilder.DropForeignKey(
                name: "FK_Apply_Users_StudentUserId",
                table: "Apply");

            migrationBuilder.DropForeignKey(
                name: "FK_Apply_Users_TeacherUserId",
                table: "Apply");

            migrationBuilder.DropForeignKey(
                name: "FK_Apply_Works_WorkId",
                table: "Apply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apply",
                table: "Apply");

            migrationBuilder.RenameTable(
                name: "Apply",
                newName: "Applies");

            migrationBuilder.RenameIndex(
                name: "IX_Apply_WorkId",
                table: "Applies",
                newName: "IX_Applies_WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Apply_TeacherUserId",
                table: "Applies",
                newName: "IX_Applies_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Apply_StudentUserId",
                table: "Applies",
                newName: "IX_Applies_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Apply_ResumeId",
                table: "Applies",
                newName: "IX_Applies_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applies",
                table: "Applies",
                column: "ApplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Resumes_ResumeId",
                table: "Applies",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Users_StudentUserId",
                table: "Applies",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Users_TeacherUserId",
                table: "Applies",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applies_Works_WorkId",
                table: "Applies",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Resumes_ResumeId",
                table: "Applies");

            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Users_StudentUserId",
                table: "Applies");

            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Users_TeacherUserId",
                table: "Applies");

            migrationBuilder.DropForeignKey(
                name: "FK_Applies_Works_WorkId",
                table: "Applies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applies",
                table: "Applies");

            migrationBuilder.RenameTable(
                name: "Applies",
                newName: "Apply");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_WorkId",
                table: "Apply",
                newName: "IX_Apply_WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_TeacherUserId",
                table: "Apply",
                newName: "IX_Apply_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_StudentUserId",
                table: "Apply",
                newName: "IX_Apply_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_ResumeId",
                table: "Apply",
                newName: "IX_Apply_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apply",
                table: "Apply",
                column: "ApplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apply_Resumes_ResumeId",
                table: "Apply",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apply_Users_StudentUserId",
                table: "Apply",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apply_Users_TeacherUserId",
                table: "Apply",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apply_Works_WorkId",
                table: "Apply",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
