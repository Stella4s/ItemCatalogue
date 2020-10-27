using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCatalogue.Migrations
{
    public partial class CompositeItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quality",
                table: "InvItems",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CompositeItem",
                columns: table => new
                {
                    ParentItemID = table.Column<int>(nullable: false),
                    ChildItemID = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositeItem", x => new { x.ParentItemID, x.ChildItemID });
                    table.ForeignKey(
                        name: "FK_CompositeItem_BaseItems_ChildItemID",
                        column: x => x.ChildItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompositeItem_BaseItems_ParentItemID",
                        column: x => x.ParentItemID,
                        principalTable: "BaseItems",
                        principalColumn: "BaseItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompositeItem_ChildItemID",
                table: "CompositeItem",
                column: "ChildItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompositeItem");

            migrationBuilder.AlterColumn<int>(
                name: "Quality",
                table: "InvItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
