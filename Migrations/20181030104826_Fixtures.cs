using Microsoft.EntityFrameworkCore.Migrations;

namespace LJWebsite.Migrations
{
    public partial class Fixtures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionTemplateDatas");

            migrationBuilder.AddColumn<bool>(
                name: "MultiChannel",
                table: "FunctionTemplates",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vendor = table.Column<string>(maxLength: 50, nullable: true),
                    PartNr = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ManualUrl = table.Column<string>(nullable: true),
                    MaxChannels = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FunctionTemplateChannels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FunctionTemplateRefID = table.Column<int>(nullable: false),
                    ColorKeyId = table.Column<int>(nullable: true),
                    ValueRangeFrom = table.Column<int>(nullable: false),
                    ValueRangeTo = table.Column<int>(nullable: false),
                    Channel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTemplateChannels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateChannels_ColorKeys_ColorKeyId",
                        column: x => x.ColorKeyId,
                        principalTable: "ColorKeys",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateChannels_FunctionTemplates_FunctionTemplateRefID",
                        column: x => x.FunctionTemplateRefID,
                        principalTable: "FunctionTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionTemplateValues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FunctionTemplateRefID = table.Column<int>(nullable: false),
                    ColorKeyId = table.Column<int>(nullable: true),
                    ValueRangeFrom = table.Column<int>(nullable: false),
                    ValueRangeTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTemplateValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateValues_ColorKeys_ColorKeyId",
                        column: x => x.ColorKeyId,
                        principalTable: "ColorKeys",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FunctionTemplateValues_FunctionTemplates_FunctionTemplateRefID",
                        column: x => x.FunctionTemplateRefID,
                        principalTable: "FunctionTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureFunctions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FixtureID = table.Column<int>(nullable: false),
                    ControllerFunctionID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MultiChannel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureFunctions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixtureFunctions_ControllerFunctions_ControllerFunctionID",
                        column: x => x.ControllerFunctionID,
                        principalTable: "ControllerFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixtureFunctions_Fixtures_FixtureID",
                        column: x => x.FixtureID,
                        principalTable: "Fixtures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixtureFunctionChannels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FixtureFunctionID = table.Column<int>(nullable: true),
                    ColorKeyId = table.Column<int>(nullable: true),
                    ValueRangeFrom = table.Column<int>(nullable: false),
                    ValueRangeTo = table.Column<int>(nullable: false),
                    Channel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureFunctionChannels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixtureFunctionChannels_ColorKeys_ColorKeyId",
                        column: x => x.ColorKeyId,
                        principalTable: "ColorKeys",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureFunctionChannels_FixtureFunctions_FixtureFunctionID",
                        column: x => x.FixtureFunctionID,
                        principalTable: "FixtureFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixtureFunctionValues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FixtureFunctionID = table.Column<int>(nullable: true),
                    ColorKeyId = table.Column<int>(nullable: true),
                    ValueRangeFrom = table.Column<int>(nullable: false),
                    ValueRangeTo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureFunctionValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FixtureFunctionValues_ColorKeys_ColorKeyId",
                        column: x => x.ColorKeyId,
                        principalTable: "ColorKeys",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixtureFunctionValues_FixtureFunctions_FixtureFunctionID",
                        column: x => x.FixtureFunctionID,
                        principalTable: "FixtureFunctions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctionChannels_ColorKeyId",
                table: "FixtureFunctionChannels",
                column: "ColorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctionChannels_FixtureFunctionID",
                table: "FixtureFunctionChannels",
                column: "FixtureFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctions_ControllerFunctionID",
                table: "FixtureFunctions",
                column: "ControllerFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctions_FixtureID",
                table: "FixtureFunctions",
                column: "FixtureID");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctionValues_ColorKeyId",
                table: "FixtureFunctionValues",
                column: "ColorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_FixtureFunctionValues_FixtureFunctionID",
                table: "FixtureFunctionValues",
                column: "FixtureFunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateChannels_ColorKeyId",
                table: "FunctionTemplateChannels",
                column: "ColorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateChannels_FunctionTemplateRefID",
                table: "FunctionTemplateChannels",
                column: "FunctionTemplateRefID");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateValues_ColorKeyId",
                table: "FunctionTemplateValues",
                column: "ColorKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTemplateValues_FunctionTemplateRefID",
                table: "FunctionTemplateValues",
                column: "FunctionTemplateRefID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixtureFunctionChannels");

            migrationBuilder.DropTable(
                name: "FixtureFunctionValues");

            migrationBuilder.DropTable(
                name: "FunctionTemplateChannels");

            migrationBuilder.DropTable(
                name: "FunctionTemplateValues");

            migrationBuilder.DropTable(
                name: "FixtureFunctions");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropColumn(
                name: "MultiChannel",
                table: "FunctionTemplates");

            migrationBuilder.CreateTable(
                name: "FunctionTemplateDatas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Channel = table.Column<int>(nullable: false),
                    ColorKeyId = table.Column<int>(nullable: true),
                    FunctionTemplateID = table.Column<int>(nullable: true),
                    FunctionTemplteID = table.Column<int>(nullable: false),
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
        }
    }
}
