using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class NotesEntity4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 30, 43, 352, DateTimeKind.Local).AddTicks(7233), new DateTime(2021, 9, 25, 23, 30, 43, 354, DateTimeKind.Local).AddTicks(2616) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 22, 43, 635, DateTimeKind.Local).AddTicks(6154), new DateTime(2021, 9, 25, 23, 22, 43, 637, DateTimeKind.Local).AddTicks(4856) });
        }
    }
}
