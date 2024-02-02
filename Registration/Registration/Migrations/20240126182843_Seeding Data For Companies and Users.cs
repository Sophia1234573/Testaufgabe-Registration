using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Registration.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForCompaniesandUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BranchId", "Name" },
                values: new object[,]
                {
                    { new Guid("a0481244-7096-452c-8a26-1dd46d3ebe06"), new Guid("6b13fc40-ca47-1067-b31d-00dd010662da"), "CompanyName1" },
                    { new Guid("a8ba4c30-7513-41eb-854b-7325b5efd316"), new Guid("6b29fc40-ca47-1067-b31d-00dd010662da"), "CompanyName2" },
                    { new Guid("dc68dd36-3724-4499-9275-5cd0d57071c2"), new Guid("6b05fc40-ca47-1067-b31d-00dd010662da"), "CompanyName3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyId", "Email", "FirstName", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("ae88b444-4e3d-4085-9487-5af928251e95"), new Guid("a0481244-7096-452c-8a26-1dd46d3ebe06"), "Username1@gmail.com", "FirstName1", "LastName1", "Password1", "Username1" },
                    { new Guid("de861852-adc7-41aa-86f2-c6e4bd502eab"), new Guid("dc68dd36-3724-4499-9275-5cd0d57071c2"), "Username3@gmail.com", "FirstName3", "LastName3", "Password3", "Username3" },
                    { new Guid("e667decc-a5a8-46f1-a500-566001c4bbb2"), new Guid("a8ba4c30-7513-41eb-854b-7325b5efd316"), "Username2@gmail.com", "FirstName2", "LastName2", "Password2", "Username2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ae88b444-4e3d-4085-9487-5af928251e95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de861852-adc7-41aa-86f2-c6e4bd502eab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e667decc-a5a8-46f1-a500-566001c4bbb2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a0481244-7096-452c-8a26-1dd46d3ebe06"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a8ba4c30-7513-41eb-854b-7325b5efd316"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("dc68dd36-3724-4499-9275-5cd0d57071c2"));
        }
    }
}
