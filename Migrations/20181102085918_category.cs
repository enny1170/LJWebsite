using Microsoft.EntityFrameworkCore.Migrations;

namespace LJWebsite.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Fixtures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_CategoryID",
                table: "Fixtures",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Category_CategoryID",
                table: "Fixtures",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Category_CategoryID",
                table: "Fixtures");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Fixtures_CategoryID",
                table: "Fixtures");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Fixtures");
        }
    }
}
