using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketToCode.Core.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndTime", "MaxAttendees", "Name", "Price", "StartTime", "Type" },
                values: new object[,]
                {
                    { 4, "En heldag med musik, mat och aktiviteter vid vattnet i Göteborg.", new DateTime(2025, 7, 6, 23, 0, 0, 0, DateTimeKind.Utc), 20000, "Sommarfestival: Göteborg Sounds", 750m, new DateTime(2025, 7, 6, 14, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 5, "Skrattgaranti när Petra Mede bjuder på humor i världsklass.", new DateTime(2025, 9, 12, 21, 0, 0, 0, DateTimeKind.Utc), 800, "Stand-up Night med Petra Mede", 450m, new DateTime(2025, 9, 12, 19, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 6, "En klassisk föreställning av Carmen i storslagen miljö.", new DateTime(2025, 11, 3, 21, 30, 0, 0, DateTimeKind.Utc), 1200, "Operakväll: Carmen på Kungliga Operan", 650m, new DateTime(2025, 11, 3, 18, 30, 0, 0, DateTimeKind.Utc), 2 },
                    { 7, "Testa nya spel, träffa influencers och upplev e-sport live.", new DateTime(2025, 8, 22, 18, 0, 0, 0, DateTimeKind.Utc), 10000, "Gaming Expo Stockholm 2025", 300m, new DateTime(2025, 8, 22, 10, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 8, "Traditionell julmarknad med hantverk, glögg och julstämning.", new DateTime(2025, 12, 14, 17, 0, 0, 0, DateTimeKind.Utc), 5000, "Julmarknad i Gamla Stan", 0m, new DateTime(2025, 12, 14, 11, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 9, "Upplev Ghosts mörka rockshow live i Globen.", new DateTime(2025, 10, 18, 23, 0, 0, 0, DateTimeKind.Utc), 16000, "Rockkväll med Ghost", 950m, new DateTime(2025, 10, 18, 20, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 10, "En intim kväll med livemusik i Hagaparken.", new DateTime(2025, 7, 20, 22, 30, 0, 0, DateTimeKind.Utc), 1000, "Jazz under Stjärnorna", 300m, new DateTime(2025, 7, 20, 19, 30, 0, 0, DateTimeKind.Utc), 0 },
                    { 11, "Tre dagar med food trucks, live-DJs och god stämning.", new DateTime(2025, 8, 3, 22, 0, 0, 0, DateTimeKind.Utc), 8000, "Street Food Festival Malmö", 100m, new DateTime(2025, 8, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 12, "Musik, segling och skärgårdskultur för hela familjen.", new DateTime(2025, 6, 29, 20, 0, 0, 0, DateTimeKind.Utc), 3000, "Skärgårdsfestivalen Vaxholm", 250m, new DateTime(2025, 6, 29, 11, 0, 0, 0, DateTimeKind.Utc), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
