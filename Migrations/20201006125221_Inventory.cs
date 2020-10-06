using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class Inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvItems_Items_BaseItemID",
                table: "InvItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "BaseItems");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryID",
                table: "BaseItems",
                newName: "IX_BaseItems_CategoryID");

            migrationBuilder.AddColumn<string>(
                name: "InventoryID",
                table: "InvItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseItems",
                table: "BaseItems",
                column: "BaseItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseItems_Categories_CategoryID",
                table: "BaseItems",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvItems_BaseItems_BaseItemID",
                table: "InvItems",
                column: "BaseItemID",
                principalTable: "BaseItems",
                principalColumn: "BaseItemID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseItems_Categories_CategoryID",
                table: "BaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvItems_BaseItems_BaseItemID",
                table: "InvItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseItems",
                table: "BaseItems");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "InvItems");

            migrationBuilder.RenameTable(
                name: "BaseItems",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_BaseItems_CategoryID",
                table: "Items",
                newName: "IX_Items_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "BaseItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_InvItems_Items_BaseItemID",
                table: "InvItems",
                column: "BaseItemID",
                principalTable: "Items",
                principalColumn: "BaseItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
