using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SyaBackend.Migrations
{
    public partial class ChangeMessageLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "MessageLibraries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ContentType",
                table: "MessageLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageType",
                table: "MessageLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MessageLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "MessageLibraries",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Applies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "MessageLibraries");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "MessageLibraries");

            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "MessageLibraries");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MessageLibraries");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "MessageLibraries");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Applies");
        }
    }
}
