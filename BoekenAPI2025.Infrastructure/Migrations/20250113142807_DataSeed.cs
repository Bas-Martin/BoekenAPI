using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoekenAPI2025.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boeken",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boeken",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schrijvers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schrijvers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
