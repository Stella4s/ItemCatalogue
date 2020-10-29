using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class ResultAndSubItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompositeItem");

            migrationBuilder.CreateTable(
                name: "ItemComposite",
                columns: table => new
                {
                    ResultItemID = table.Column<int>(nullable: false),
                    SubItemID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComposite", x => new { x.ResultItemID, x.SubItemID });
                    table.ForeignKey(
                        name: "FK_ItemComposite_BaseItems_ResultItemID",
                        column: x => x.ResultItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemComposite_BaseItems_SubItemID",
                        column: x => x.SubItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemComposite_SubItemID",
                table: "ItemComposite",
                column: "SubItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemComposite");

            migrationBuilder.CreateTable(
                name: "CompositeItem",
                columns: table => new
                {
                    ParentItemID = table.Column<int>(type: "int", nullable: false),
                    ChildItemID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositeItem", x => new { x.ParentItemID, x.ChildItemID });
                    table.ForeignKey(
                        name: "FK_CompositeItem_BaseItems_ChildItemID",
                        column: x => x.ChildItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompositeItem_BaseItems_ParentItemID",
                        column: x => x.ParentItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompositeItem_ChildItemID",
                table: "CompositeItem",
                column: "ChildItemID");
        }
    }
}
