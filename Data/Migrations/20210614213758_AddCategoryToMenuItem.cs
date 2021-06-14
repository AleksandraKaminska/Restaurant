using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddCategoryToMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "MenuItems",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "MenuItems");
        }
    }
}
