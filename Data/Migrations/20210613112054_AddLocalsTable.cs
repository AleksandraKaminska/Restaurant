using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Data.Migrations
{
    public partial class AddLocalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Local_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Local_Menu_Id",
                table: "Local");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "Locals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locals",
                table: "Locals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Locals_Id",
                table: "Employee",
                column: "Id",
                principalTable: "Locals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locals_Menu_Id",
                table: "Locals",
                column: "Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Locals_Id",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Locals_Menu_Id",
                table: "Locals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locals",
                table: "Locals");

            migrationBuilder.RenameTable(
                name: "Locals",
                newName: "Local");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "Local",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Local_Id",
                table: "Employee",
                column: "Id",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Menu_Id",
                table: "Local",
                column: "Id",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
