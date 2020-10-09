using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class TempImageFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 1,
                column: "ImageUrl",
                value: "TempItem1.png");

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 2,
                column: "ImageUrl",
                value: "TempItem1.png");

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 3,
                column: "ImageUrl",
                value: "TempItem2.png");

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 4,
                column: "ImageUrl",
                value: "TempItem2.png");

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 5,
                column: "ImageUrl",
                value: "TempItem3.png");

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 6,
                column: "ImageUrl",
                value: "TempItem2.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "BaseItems",
                keyColumn: "BaseItemID",
                keyValue: 6,
                column: "ImageUrl",
                value: null);
        }
    }
}
