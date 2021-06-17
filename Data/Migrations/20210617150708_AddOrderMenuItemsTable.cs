using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddOrderMenuItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderMenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_MenuItemId",
                table: "OrderMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_OrderId",
                table: "OrderMenuItems",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMenuItems");
        }
    }
}
