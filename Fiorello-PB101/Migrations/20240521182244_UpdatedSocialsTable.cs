using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_PB101.Migrations
{
    public partial class UpdatedSocialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7945), "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"20\"  height=\"20\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-x\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M4 4l11.733 16h4.267l-11.733 -16z\" /><path d=\"M4 20l6.768 -6.768m2.46 -2.46l6.772 -6.772\" /></svg>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7947), "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"20\"  height=\"20\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-instagram\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M4 4m0 4a4 4 0 0 1 4 -4h8a4 4 0 0 1 4 4v8a4 4 0 0 1 -4 4h-8a4 4 0 0 1 -4 -4z\" /><path d=\"M12 12m-3 0a3 3 0 1 0 6 0a3 3 0 1 0 -6 0\" /><path d=\"M16.5 7.5l0 .01\" /></svg>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7950), "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"20\"  height=\"20\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-tumblr\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M14 21h4v-4h-4v-6h4v-4h-4v-4h-4v1a3 3 0 0 1 -3 3h-1v4h4v6a4 4 0 0 0 4 4\" /></svg>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 22, 22, 44, 254, DateTimeKind.Local).AddTicks(7952), "<svg  xmlns=\"http://www.w3.org/2000/svg\"  width=\"20\"  height=\"20\"  viewBox=\"0 0 24 24\"  fill=\"none\"  stroke=\"currentColor\"  stroke-width=\"2\"  stroke-linecap=\"round\"  stroke-linejoin=\"round\"  class=\"icon icon-tabler icons-tabler-outline icon-tabler-brand-pinterest\"><path stroke=\"none\" d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M8 20l4 -9\" /><path d=\"M10.7 14c.437 1.263 1.43 2 2.55 2c2.071 0 3.75 -1.554 3.75 -4a5 5 0 1 0 -9.7 1.7\" /><path d=\"M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0\" /></svg>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7086), "<i class=\"fa-brands fa-twitter\"></i>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7087), "<i class=\"fa-brands fa-instagram\"></i>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7088), "<i class=\"fa-brands fa-tumblr\"></i>" });

            migrationBuilder.UpdateData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Icon" },
                values: new object[] { new DateTime(2024, 5, 21, 21, 54, 18, 338, DateTimeKind.Local).AddTicks(7089), "<i class=\"fa-brands fa-pinterest\"></i>" });
        }
    }
}
