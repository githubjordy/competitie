using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wedstrijdplannenmvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    punten = table.Column<int>(type: "int", nullable: false),
                    doelpuntentegen = table.Column<int>(type: "int", nullable: false),
                    doelpuntenvoor = table.Column<int>(type: "int", nullable: false),
                    doelsaldo = table.Column<int>(type: "int", nullable: false),
                    wedstrijdengespeeld = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wedstrijden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thuisteamuitslag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uitteamuitslag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thuisteam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedstrijden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamWedstrijd",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    WedstrijdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamWedstrijd", x => new { x.TeamId, x.WedstrijdId });
                    table.ForeignKey(
                        name: "FK_TeamWedstrijd_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamWedstrijd_Wedstrijden_WedstrijdId",
                        column: x => x.WedstrijdId,
                        principalTable: "Wedstrijden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamWedstrijd_WedstrijdId",
                table: "TeamWedstrijd",
                column: "WedstrijdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamWedstrijd");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Wedstrijden");
        }
    }
}
