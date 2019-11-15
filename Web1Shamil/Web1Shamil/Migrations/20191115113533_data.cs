using Microsoft.EntityFrameworkCore.Migrations;

namespace Web1Shamil.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionsName = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionsId);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StageName = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.StageId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamsName = table.Column<string>(nullable: true),
                    TeamsStadium = table.Column<string>(nullable: true),
                    RegionsId = table.Column<int>(nullable: true),
                    StageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamsId);
                    table.ForeignKey(
                        name: "FK_Teams_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "RegionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "StageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    CoachId = table.Column<int>(nullable: false),
                    CoachName = table.Column<string>(maxLength: 16, nullable: false),
                    CoachSurname = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.CoachId);
                    table.ForeignKey(
                        name: "FK_Coach_Teams_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Teams",
                        principalColumn: "TeamsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayersId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayersName = table.Column<string>(maxLength: 16, nullable: false),
                    PlayersSurname = table.Column<string>(maxLength: 16, nullable: false),
                    TeamsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayersId);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "TeamsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uniforms",
                columns: table => new
                {
                    UniformsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniformsName = table.Column<string>(maxLength: 16, nullable: false),
                    UniformsColor = table.Column<string>(maxLength: 16, nullable: false),
                    TeamsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uniforms", x => x.UniformsId);
                    table.ForeignKey(
                        name: "FK_Uniforms_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "TeamsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PositionsName = table.Column<string>(maxLength: 16, nullable: false),
                    PlayersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionsId);
                    table.ForeignKey(
                        name: "FK_Positions_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "PlayersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersPositions",
                columns: table => new
                {
                    PlayersPositionsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayersId = table.Column<int>(nullable: false),
                    PositionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersPositions", x => x.PlayersPositionsId);
                    table.ForeignKey(
                        name: "FK_PlayersPositions_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "PlayersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayersPositions_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "PositionsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamsId",
                table: "Players",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersPositions_PlayersId",
                table: "PlayersPositions",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersPositions_PositionsId",
                table: "PlayersPositions",
                column: "PositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PlayersId",
                table: "Positions",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RegionsId",
                table: "Teams",
                column: "RegionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StageId",
                table: "Teams",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Uniforms_TeamsId",
                table: "Uniforms",
                column: "TeamsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "PlayersPositions");

            migrationBuilder.DropTable(
                name: "Uniforms");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Stages");
        }
    }
}
