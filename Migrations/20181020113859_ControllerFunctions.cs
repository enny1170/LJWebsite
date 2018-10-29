using Microsoft.EntityFrameworkCore.Migrations;

namespace LJWebsite.Migrations
{
    public partial class ControllerFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Functionality");

            migrationBuilder.CreateTable(
                name: "ColorKeys",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColorName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorKeys", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "ControllerFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerFunctions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FunctionTemplates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ControllerFunctionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionTemplates_ControllerFunctions_ControllerFunctionID",
                        column: x => x.ControllerFunctionID,
                        principalTable: "ControllerFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionTemplateDatas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FunctionTemplteID = table.Column<int>(nullable: false),
                    FunctionTemplateID = table.Column<int>(nullable: true),
                    ColorKeyId = table.Column<int>(nullable: true),
                    Channel = table.Column<int>(nullable: false),
                    ValueRangeFrom = table.Column<int>(nullable: false),
                    ValueRangeTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTemplateDatas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateDatas_ColorKeys_ColorKeyId",
                        column: x => x.ColorKeyId,
                        principalTable: "ColorKeys",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateDatas_FunctionTemplates_FunctionTemplateID",
                        column: x => x.FunctionTemplateID,
                        principalTable: "FunctionTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateDatas_ColorKeyId",
                table: "FunctionTemplateDatas",
                column: "ColorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateDatas_FunctionTemplateID",
                table: "FunctionTemplateDatas",
                column: "FunctionTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplates_ControllerFunctionID",
                table: "FunctionTemplates",
                column: "ControllerFunctionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionTemplateDatas");

            migrationBuilder.DropTable(
                name: "ColorKeys");

            migrationBuilder.DropTable(
                name: "FunctionTemplates");

            migrationBuilder.DropTable(
                name: "ControllerFunctions");

            migrationBuilder.CreateTable(
                name: "Functionality",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    IsMultiChannel = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionality", x => x.ID);
                });
        }
    }
}
