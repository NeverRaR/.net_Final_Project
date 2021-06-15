using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_Users_UserId",
                table: "Announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_announcement_send_Announcement_AnnouncementId",
                table: "announcement_send");

            migrationBuilder.DropForeignKey(
                name: "FK_announcement_send_Users_ReceiverId",
                table: "announcement_send");

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

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_has_work_Favorites_FavoriteId",
                table: "favorite_has_work");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_has_work_Works_WorkId",
                table: "favorite_has_work");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_information_Users_StudentUserId",
                table: "leave_information");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_information_Works_WorkId",
                table: "leave_information");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_StudentId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Works_WorkId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_message_library_Users_ReceiverUserId",
                table: "message_library");

            migrationBuilder.DropForeignKey(
                name: "FK_message_library_Users_SenderUserId",
                table: "message_library");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Users_StudentId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Takes_Users_StudentId",
                table: "Takes");

            migrationBuilder.DropForeignKey(
                name: "FK_Takes_Works_WorkId",
                table: "Takes");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_TeacherUserId",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Takes",
                table: "Takes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcement",
                table: "Announcement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applies",
                table: "Applies");

            migrationBuilder.RenameTable(
                name: "Takes",
                newName: "takes");

            migrationBuilder.RenameTable(
                name: "Announcement",
                newName: "announcement");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "work");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Resumes",
                newName: "resume");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "work_like");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "favorite");

            migrationBuilder.RenameTable(
                name: "Applies",
                newName: "apply");

            migrationBuilder.RenameIndex(
                name: "IX_Takes_StudentId",
                table: "takes",
                newName: "IX_takes_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Announcement_UserId",
                table: "announcement",
                newName: "IX_announcement_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Works_TeacherUserId",
                table: "work",
                newName: "IX_work_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_StudentId",
                table: "resume",
                newName: "IX_resume_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_StudentId",
                table: "work_like",
                newName: "IX_work_like_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserId",
                table: "favorite",
                newName: "IX_favorite_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_WorkId",
                table: "apply",
                newName: "IX_apply_WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_TeacherUserId",
                table: "apply",
                newName: "IX_apply_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_StudentUserId",
                table: "apply",
                newName: "IX_apply_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applies_ResumeId",
                table: "apply",
                newName: "IX_apply_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_takes",
                table: "takes",
                columns: new[] { "WorkId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_announcement",
                table: "announcement",
                column: "AnnouncementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_work",
                table: "work",
                column: "WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resume",
                table: "resume",
                column: "ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_work_like",
                table: "work_like",
                columns: new[] { "WorkId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorite",
                table: "favorite",
                column: "FavoriteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_apply",
                table: "apply",
                column: "ApplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_announcement_user_UserId",
                table: "announcement",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_announcement_send_announcement_AnnouncementId",
                table: "announcement_send",
                column: "AnnouncementId",
                principalTable: "announcement",
                principalColumn: "AnnouncementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_announcement_send_user_ReceiverId",
                table: "announcement_send",
                column: "ReceiverId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_apply_resume_ResumeId",
                table: "apply",
                column: "ResumeId",
                principalTable: "resume",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_apply_user_StudentUserId",
                table: "apply",
                column: "StudentUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_apply_user_TeacherUserId",
                table: "apply",
                column: "TeacherUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_apply_work_WorkId",
                table: "apply",
                column: "WorkId",
                principalTable: "work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_user_UserId",
                table: "favorite",
                column: "UserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_has_work_favorite_FavoriteId",
                table: "favorite_has_work",
                column: "FavoriteId",
                principalTable: "favorite",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_has_work_work_WorkId",
                table: "favorite_has_work",
                column: "WorkId",
                principalTable: "work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_information_user_StudentUserId",
                table: "leave_information",
                column: "StudentUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_information_work_WorkId",
                table: "leave_information",
                column: "WorkId",
                principalTable: "work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_message_library_user_ReceiverUserId",
                table: "message_library",
                column: "ReceiverUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_message_library_user_SenderUserId",
                table: "message_library",
                column: "SenderUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_resume_user_StudentId",
                table: "resume",
                column: "StudentId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_takes_user_StudentId",
                table: "takes",
                column: "StudentId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_takes_work_WorkId",
                table: "takes",
                column: "WorkId",
                principalTable: "work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_work_user_TeacherUserId",
                table: "work",
                column: "TeacherUserId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_work_like_user_StudentId",
                table: "work_like",
                column: "StudentId",
                principalTable: "user",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_work_like_work_WorkId",
                table: "work_like",
                column: "WorkId",
                principalTable: "work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_announcement_user_UserId",
                table: "announcement");

            migrationBuilder.DropForeignKey(
                name: "FK_announcement_send_announcement_AnnouncementId",
                table: "announcement_send");

            migrationBuilder.DropForeignKey(
                name: "FK_announcement_send_user_ReceiverId",
                table: "announcement_send");

            migrationBuilder.DropForeignKey(
                name: "FK_apply_resume_ResumeId",
                table: "apply");

            migrationBuilder.DropForeignKey(
                name: "FK_apply_user_StudentUserId",
                table: "apply");

            migrationBuilder.DropForeignKey(
                name: "FK_apply_user_TeacherUserId",
                table: "apply");

            migrationBuilder.DropForeignKey(
                name: "FK_apply_work_WorkId",
                table: "apply");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_user_UserId",
                table: "favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_has_work_favorite_FavoriteId",
                table: "favorite_has_work");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_has_work_work_WorkId",
                table: "favorite_has_work");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_information_user_StudentUserId",
                table: "leave_information");

            migrationBuilder.DropForeignKey(
                name: "FK_leave_information_work_WorkId",
                table: "leave_information");

            migrationBuilder.DropForeignKey(
                name: "FK_message_library_user_ReceiverUserId",
                table: "message_library");

            migrationBuilder.DropForeignKey(
                name: "FK_message_library_user_SenderUserId",
                table: "message_library");

            migrationBuilder.DropForeignKey(
                name: "FK_resume_user_StudentId",
                table: "resume");

            migrationBuilder.DropForeignKey(
                name: "FK_takes_user_StudentId",
                table: "takes");

            migrationBuilder.DropForeignKey(
                name: "FK_takes_work_WorkId",
                table: "takes");

            migrationBuilder.DropForeignKey(
                name: "FK_work_user_TeacherUserId",
                table: "work");

            migrationBuilder.DropForeignKey(
                name: "FK_work_like_user_StudentId",
                table: "work_like");

            migrationBuilder.DropForeignKey(
                name: "FK_work_like_work_WorkId",
                table: "work_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_takes",
                table: "takes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_announcement",
                table: "announcement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_work_like",
                table: "work_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_work",
                table: "work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_resume",
                table: "resume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorite",
                table: "favorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_apply",
                table: "apply");

            migrationBuilder.RenameTable(
                name: "takes",
                newName: "Takes");

            migrationBuilder.RenameTable(
                name: "announcement",
                newName: "Announcement");

            migrationBuilder.RenameTable(
                name: "work_like",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "work",
                newName: "Works");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "resume",
                newName: "Resumes");

            migrationBuilder.RenameTable(
                name: "favorite",
                newName: "Favorites");

            migrationBuilder.RenameTable(
                name: "apply",
                newName: "Applies");

            migrationBuilder.RenameIndex(
                name: "IX_takes_StudentId",
                table: "Takes",
                newName: "IX_Takes_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_announcement_UserId",
                table: "Announcement",
                newName: "IX_Announcement_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_work_like_StudentId",
                table: "Likes",
                newName: "IX_Likes_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_work_TeacherUserId",
                table: "Works",
                newName: "IX_Works_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_resume_StudentId",
                table: "Resumes",
                newName: "IX_Resumes_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_favorite_UserId",
                table: "Favorites",
                newName: "IX_Favorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_apply_WorkId",
                table: "Applies",
                newName: "IX_Applies_WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_apply_TeacherUserId",
                table: "Applies",
                newName: "IX_Applies_TeacherUserId");

            migrationBuilder.RenameIndex(
                name: "IX_apply_StudentUserId",
                table: "Applies",
                newName: "IX_Applies_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_apply_ResumeId",
                table: "Applies",
                newName: "IX_Applies_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Takes",
                table: "Takes",
                columns: new[] { "WorkId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcement",
                table: "Announcement",
                column: "AnnouncementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "WorkId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "WorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "FavoriteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applies",
                table: "Applies",
                column: "ApplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_Users_UserId",
                table: "Announcement",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_announcement_send_Announcement_AnnouncementId",
                table: "announcement_send",
                column: "AnnouncementId",
                principalTable: "Announcement",
                principalColumn: "AnnouncementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_announcement_send_Users_ReceiverId",
                table: "announcement_send",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_has_work_Favorites_FavoriteId",
                table: "favorite_has_work",
                column: "FavoriteId",
                principalTable: "Favorites",
                principalColumn: "FavoriteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_has_work_Works_WorkId",
                table: "favorite_has_work",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_information_Users_StudentUserId",
                table: "leave_information",
                column: "StudentUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leave_information_Works_WorkId",
                table: "leave_information",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_StudentId",
                table: "Likes",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Works_WorkId",
                table: "Likes",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_library_Users_ReceiverUserId",
                table: "message_library",
                column: "ReceiverUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_message_library_Users_SenderUserId",
                table: "message_library",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Users_StudentId",
                table: "Resumes",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Takes_Users_StudentId",
                table: "Takes",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Takes_Works_WorkId",
                table: "Takes",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_TeacherUserId",
                table: "Works",
                column: "TeacherUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
