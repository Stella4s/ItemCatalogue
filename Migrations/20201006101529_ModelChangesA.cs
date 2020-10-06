using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class ModelChangesA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

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

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "BaseItemID",
                table: "Items",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "BaseItemID");

            migrationBuilder.CreateTable(
                name: "InvItems",
                columns: table => new
                {
                    InvItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseItemID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvItems", x => x.InvItemID);
                    table.ForeignKey(
                        name: "FK_InvItems_Items_BaseItemID",
                        column: x => x.BaseItemID,
                        principalTable: "Items",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "BaseItemID", "BasePrice", "CategoryID", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 4.50m, 3, "A delicious fresh apple.", null, "Apple" },
                    { 2, 23.00m, 3, "A classic.", null, "ApplePie" },
                    { 3, 2.30m, 1, "Regular old flour.", null, "Flour" },
                    { 4, 6.50m, 1, "A fancy way of saying apple juice.", null, "Apple Extract" },
                    { 5, 6.50m, 2, "Good in a pinch.", null, "Health Potion" },
                    { 6, 9.00m, 1, "Yikes.", null, "Newt's eye" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvItems_BaseItemID",
                table: "InvItems",
                column: "BaseItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "BaseItemID",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "BaseItemID",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quality",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "BasePrice", "CategoryID", "Description", "ImageUrl", "Name", "Price", "Quality" },
                values: new object[,]
                {
                    { 1, 4.50m, 3, "A delicious fresh apple.", null, "Apple", 0m, 0 },
                    { 2, 23.00m, 3, "A classic.", null, "ApplePie", 0m, 0 },
                    { 3, 2.30m, 1, "Regular old flour.", null, "Flour", 0m, 0 },
                    { 4, 6.50m, 1, "A fancy way of saying apple juice.", null, "Apple Extract", 0m, 0 },
                    { 5, 6.50m, 2, "Good in a pinch.", null, "Health Potion", 0m, 0 }
                });
        }
    }
}
