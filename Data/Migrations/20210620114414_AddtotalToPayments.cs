using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddtotalToPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "Payments",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Payments");
        }
    }
}
