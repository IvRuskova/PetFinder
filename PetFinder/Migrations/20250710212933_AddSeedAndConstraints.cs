using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Migrations
{
    public partial class AddSeedAndConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_ApplicationUserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_ApplicationUserId",
                table: "Owners");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Owners",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ChipSearchLogs",
                columns: new[] { "Id", "ChipNumber", "ChipNumberSearched", "IpAddress", "SearchDate" },
                values: new object[,]
                {
                    { 1, "BG123456", "", "192.168.1.100", new DateTime(2025, 7, 9, 21, 29, 33, 156, DateTimeKind.Utc).AddTicks(2437) },
                    { 2, "BG654321", "", "192.168.1.101", new DateTime(2025, 7, 10, 21, 29, 33, 156, DateTimeKind.Utc).AddTicks(2440) }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "ApplicationUserId", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ul. Bylgaria 125, Sofia", null, "ivan@example.com", "Ivan Ivanov", "0888123456" },
                    { 2, "Lulin 10, Sofia", null, "maria@abv.bg", "Maria Georgiewa", "0899111222" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "BreedId", "ChipNumber", "Name", "OwnerId", "Status" },
                values: new object[] { 1, 3, 1, "BG123456", "Rex", 1, 0 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Age", "BreedId", "ChipNumber", "Name", "OwnerId", "Status" },
                values: new object[] { 2, 5, 2, "BG654321", "Bony", 2, 2 });

            migrationBuilder.InsertData(
                table: "VetReports",
                columns: new[] { "Id", "Date", "Description", "DogId", "ReporterName" },
                values: new object[] { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vaccination and check.", 1, "" });

            migrationBuilder.InsertData(
                table: "VetReports",
                columns: new[] { "Id", "Date", "Description", "DogId", "ReporterName" },
                values: new object[] { 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treatment.", 2, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ApplicationUserId",
                table: "Owners",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_ChipNumber",
                table: "Dogs",
                column: "ChipNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_ApplicationUserId",
                table: "Owners",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_AspNetUsers_ApplicationUserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_ApplicationUserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_ChipNumber",
                table: "Dogs");

            migrationBuilder.DeleteData(
                table: "ChipSearchLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChipSearchLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VetReports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VetReports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
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
                name: "Status",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Owners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ApplicationUserId",
                table: "Owners",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_AspNetUsers_ApplicationUserId",
                table: "Owners",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
