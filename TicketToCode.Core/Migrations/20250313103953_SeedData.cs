using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketToCode.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndTime", "MaxAttendees", "Name", "StartTime", "Type" },
                values: new object[,]
                {
                    { 1, "En magisk kväll med Coldplay på Friends Arena", new DateTime(2025, 5, 10, 21, 0, 0, 0, DateTimeKind.Utc), 50000, "Livekonsert: Coldplay", new DateTime(2025, 5, 10, 18, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 2, "Upptäck smaker från hela världen på en helg fylld med mat", new DateTime(2025, 6, 15, 17, 0, 0, 0, DateTimeKind.Utc), 300, "Matfestival 2025", new DateTime(2025, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 3, "Programmerare tävlar om att skapa den bästa AI-lösningen", new DateTime(2025, 5, 10, 21, 0, 0, 0, DateTimeKind.Utc), 150, "Hackathon AI Challenge", new DateTime(2025, 5, 10, 18, 0, 0, 0, DateTimeKind.Utc), 3 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Solenskiner123", "Admin", "Admin1" },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Solenskiner123", "User", "User1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
