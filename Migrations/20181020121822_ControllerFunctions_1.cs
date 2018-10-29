using Microsoft.EntityFrameworkCore.Migrations;

namespace LJWebsite.Migrations
{
    public partial class ControllerFunctions_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FunctionTemplates",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FunctionTemplates");
        }
    }
}
