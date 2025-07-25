using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChipSearchLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the chip search log entry.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChipNumberSearched = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "The chip number that was searched for."),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the chip search was performed."),
                    ChipNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "The chip number of the dog that was found during the search."),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The IP number.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipSearchLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VetReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Veterinary Reports Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the veterinary report."),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of the veterinary report."),
                    ReporterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the person who reported the veterinary issue."),
                    DogId = table.Column<int>(type: "int", nullable: false, comment: "Identifier for the dog associated with the veterinary report.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VetReport_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-001", 0, "1d6efae6-2233-42b6-8c5b-5a589c1ae85a", "ApplicationUser", "admin@petfinder.com", false, "", false, null, "ADMIN@PETFINDER.COM", "ADMIN@PETFINDER.COM", "AQAAAAEAACcQAAAAELi87zEP45bVKGU9MHgrfhrKbBFRJqUVuXv3tfHWvbAVqWkQnO0cDS4zTiWybirPNg==", null, false, "04791ec9-8b3d-4937-b150-c62973913a14", false, "admin@petfinder.com" },
                    { "owner-001", 0, "f34eca48-f9c6-43b4-9b83-8ac719f67eae", "ApplicationUser", "owner@petfinder.com", false, "", false, null, "OWNER@PETFINDER.COM", "OWNER@PETFINDER.COM", "AQAAAAEAACcQAAAAEHlxPS+oWRDspOZl8xb+AxvAlcJfbUhs6xGxCTN7PTj1qaDOrW49CSxtQucH5u7ENg==", null, false, "23d1b01a-415d-4f89-8b6e-4f1d10bf75a2", false, "owner@petfinder.com" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "German Shepherd" },
                    { 2, "Poodle" },
                    { 3, "Akita Inu" }
                });

            migrationBuilder.InsertData(
                table: "ChipSearchLog",
                columns: new[] { "Id", "ChipNumber", "ChipNumberSearched", "IpAddress", "SearchDate" },
                values: new object[,]
                {
                    { 1, "BG123456", "", "192.168.1.100", new DateTime(2025, 7, 24, 20, 44, 43, 481, DateTimeKind.Utc).AddTicks(4184) },
                    { 2, "BG654321", "", "192.168.1.101", new DateTime(2025, 7, 25, 20, 44, 43, 481, DateTimeKind.Utc).AddTicks(4187) }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ul. Bylgaria 125, Sofia", "ivan@example.com", "Ivan Ivanov", "0888123456" },
                    { 2, "Lulin 10, Sofia", "maria@abv.bg", "Maria Georgiewa", "0899111222" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "BreedId", "ChipNumber", "Name", "OwnerId" },
                values: new object[] { 1, 3, 1, "BG123456", "Rex", 1 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "BreedId", "ChipNumber", "Name", "OwnerId" },
                values: new object[] { 2, 5, 2, "BG654321", "Bony", 2 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "BreedId", "ChipNumber", "Name", "OwnerId" },
                values: new object[] { 3, 5, 2, "BG654788", "Mia", 2 });

            migrationBuilder.InsertData(
                table: "VetReport",
                columns: new[] { "Id", "Date", "Description", "DogId", "ReporterName" },
                values: new object[] { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vaccination and check.", 1, "" });

            migrationBuilder.InsertData(
                table: "VetReport",
                columns: new[] { "Id", "Date", "Description", "DogId", "ReporterName" },
                values: new object[] { 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treatment.", 2, "" });

            migrationBuilder.CreateIndex(
                name: "IX_VetReport_DogId",
                table: "VetReport",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChipSearchLog");

            migrationBuilder.DropTable(
                name: "VetReport");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "owner-001");

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
