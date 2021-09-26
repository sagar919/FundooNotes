using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class NotesEntity5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 32, 31, 355, DateTimeKind.Local).AddTicks(3049), new DateTime(2021, 9, 25, 23, 32, 31, 357, DateTimeKind.Local).AddTicks(614) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 9, 25, 23, 30, 43, 352, DateTimeKind.Local).AddTicks(7233), new DateTime(2021, 9, 25, 23, 30, 43, 354, DateTimeKind.Local).AddTicks(2616) });
        }
    }
}
