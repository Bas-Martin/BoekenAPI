using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoekenAPI2025.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schrijvers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schrijvers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boeken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Publicatiejaar = table.Column<int>(type: "INTEGER", nullable: false),
                    AantalBladzijden = table.Column<int>(type: "INTEGER", nullable: false),
                    SchrijverId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boeken_Schrijvers_SchrijverId",
                        column: x => x.SchrijverId,
                        principalTable: "Schrijvers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schrijvers",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Mark J. Prijs" },
                    { 2, "Joseph Albahari" }
                });

            migrationBuilder.InsertData(
                table: "Boeken",
                columns: new[] { "Id", "AantalBladzijden", "Publicatiejaar", "SchrijverId", "Titel" },
                values: new object[,]
                {
                    { 1, 200, 2023, 1, "C# 8.0 and .NET Core 3.0" },
                    { 2, 100, 2023, 2, "C# 8.0 Pocket-referentie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_SchrijverId",
                table: "Boeken",
                column: "SchrijverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boeken");

            migrationBuilder.DropTable(
                name: "Schrijvers");
        }
    }
}
