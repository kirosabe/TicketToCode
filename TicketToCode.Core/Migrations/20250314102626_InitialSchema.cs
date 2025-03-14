using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketToCode.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxAttendees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$JyuqKfWwJComLQdAgl89I.ra43Hq0rlKDVUgAiKprkSqoF9vMPa5e", "Admin", "Admin1" },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "$2a$11$3tiMVpElMc0y2wZR4ox0Yuzvax4TOmkTcJAEgsiwW0XKvBUZcfN66", "User", "User1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
