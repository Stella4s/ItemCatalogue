using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "Ingredients" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "Potions" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Food" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "BasePrice", "CategoryID", "Description", "ImageUrl", "Name", "Price", "Quality" },
                values: new object[,]
                {
                    { 3, 2.30m, 1, "Regular old flour.", null, "Flour", 0m, 0 },
                    { 4, 6.50m, 1, "A fancy way of saying apple juice.", null, "Apple Extract", 0m, 0 },
                    { 5, 6.50m, 2, "Good in a pinch.", null, "Health Potion", 0m, 0 },
                    { 1, 4.50m, 3, "A delicious fresh apple.", null, "Apple", 0m, 0 },
                    { 2, 23.00m, 3, "A classic.", null, "ApplePie", 0m, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);
        }
    }
}
