using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class UpdateMenuId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Menu_MenuIdMenu",
                table: "MenuItem");

            migrationBuilder.RenameColumn(
                name: "MenuIdMenu",
                table: "MenuItem",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_MenuIdMenu",
                table: "MenuItem",
                newName: "IX_MenuItem_MenuId");

            migrationBuilder.RenameColumn(
                name: "IdMenu",
                table: "Menu",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Menu_MenuId",
                table: "MenuItem",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Menu_MenuId",
                table: "MenuItem");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "MenuItem",
                newName: "MenuIdMenu");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_MenuId",
                table: "MenuItem",
                newName: "IX_MenuItem_MenuIdMenu");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Menu",
                newName: "IdMenu");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Menu_MenuIdMenu",
                table: "MenuItem",
                column: "MenuIdMenu",
                principalTable: "Menu",
                principalColumn: "IdMenu",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
