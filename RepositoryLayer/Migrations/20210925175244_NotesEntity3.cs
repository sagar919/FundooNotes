using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class NotesEntity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "AddReminder", "Color", "CreatedDate", "Image", "IsArchive", "IsNote", "IsPin", "IsTrash", "Message", "ModifiedDate", "Title", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue", new DateTime(2021, 9, 25, 23, 22, 43, 635, DateTimeKind.Local).AddTicks(6154), "image1", false, false, false, false, "This is my first note", new DateTime(2021, 9, 25, 23, 22, 43, 637, DateTimeKind.Local).AddTicks(4856), "FirstNote", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
