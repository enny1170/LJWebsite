using Microsoft.EntityFrameworkCore.Migrations;

namespace LJWebsite.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "FixtureFunctions");

            migrationBuilder.DropTable(
                name: "FixtureFunctionChannels");

            migrationBuilder.DropTable(
                name: "FixtureFunctionValues");


            // migrationBuilder.AddColumn<int>(
            //     name: "CategoryID",
            //     table: "Fixtures",
            //     nullable: true);

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
                    MaxChannels = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.ID);
                    table.ForeignKey("FK_Fixtures_Category",
                    column: x => x.CategoryID,
                    principalTable:"Category",
                    principalColumn:"ID",
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
