using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_PB101.Migrations
{
    public partial class CreatedSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "SoftDeleted", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(77), "HeaderLogo", false, "logo.png" },
                    { 2, new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(79), "Phone", false, "234342334" },
                    { 3, new DateTime(2024, 5, 21, 18, 43, 40, 148, DateTimeKind.Local).AddTicks(80), "Address", false, "Ehmedli" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 14, 40, 24, 628, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 14, 40, 24, 628, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 14, 40, 24, 628, DateTimeKind.Local).AddTicks(86));
        }
    }
}
