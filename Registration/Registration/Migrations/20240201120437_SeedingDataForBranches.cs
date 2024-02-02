using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForBranches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6b05fc40-ca47-1067-b31d-00dd010662da"), "Ernährungsindustrie" },
                    { new Guid("6b13fc40-ca47-1067-b31d-00dd010662da"), "Automobilzulieferindustrie" },
                    { new Guid("6b15fc40-ca47-1067-b31d-00dd010662da"), "Maschinenbau und Metallverarbeitung" },
                    { new Guid("6b17fc40-ca47-1067-b31d-00dd010662da"), "Windenergieindustrie" },
                    { new Guid("6b19fc40-ca47-1067-b31d-00dd010662da"), "Luft- und Raumfahrtindustrie" },
                    { new Guid("6b25fc40-ca47-1067-b31d-00dd010662da"), "Kreativ- und Designwirtschaft" },
                    { new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "Elektroindustrie" },
                    { new Guid("6b39fc40-ca47-1067-b31d-00dd010662da"), "Maritime Industrie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b05fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b13fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b15fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b17fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b19fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b25fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("6b39fc40-ca47-1067-b31d-00dd010662da"));
        }
    }
}
