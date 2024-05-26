using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_PB101.Migrations
{
    public partial class CreatedSocialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "CreatedDate", "Icon", "Name", "SoftDeleted", "URL" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7086), "<i class=\"fa-brands fa-twitter\"></i>", "Twitter", false, "https://x.com/" },
                    { 2, new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7087), "<i class=\"fa-brands fa-instagram\"></i>", "Instagram", false, "https://www.instagram.com/" },
                    { 3, new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7088), "<i class=\"fa-brands fa-tumblr\"></i>", "Tumblr", false, "https://www.tumblr.com/" },
                    { 4, new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7089), "<i class=\"fa-brands fa-pinterest\"></i>", "Pinterest", false, "https://www.pinterest.com/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 147, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 147, DateTimeKind.Local).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(80));
        }
    }
}
