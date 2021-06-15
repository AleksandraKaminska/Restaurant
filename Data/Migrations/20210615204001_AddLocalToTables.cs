using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddLocalToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfTables",
                table: "Locals");

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Tables",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_LocalId",
                table: "Tables",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Locals_LocalId",
                table: "Tables",
                column: "LocalId",
                principalTable: "Locals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Locals_LocalId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_LocalId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Tables");

            migrationBuilder.AddColumn<int>(
                name: "NrOfTables",
                table: "Locals",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
