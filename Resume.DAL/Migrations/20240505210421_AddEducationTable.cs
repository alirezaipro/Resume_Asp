using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEducationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateOnly>(type: "date", nullable: false),
                    End = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateOnly(2024, 5, 6), new DateTime(2024, 5, 6, 0, 34, 16, 840, DateTimeKind.Local).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 6, 0, 34, 16, 840, DateTimeKind.Local).AddTicks(5305));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateOnly(2024, 4, 27), new DateTime(2024, 4, 27, 2, 38, 21, 308, DateTimeKind.Local).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 4, 27, 2, 38, 21, 307, DateTimeKind.Local).AddTicks(9684));
        }
    }
}
