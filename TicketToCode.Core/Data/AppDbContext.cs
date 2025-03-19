using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Models;
using BCrypt.Net;

namespace TicketToCode.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        // Model for test data seeding
        // To use this model, add the following code in CMD from TicketToCode.API where appsettings.json is:
        // dotnet ef database update --project ../TicketToCode.Core --startup-project .
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Admin1",
                    PasswordHash = "$2a$11$oyZpd6ltbGoVcWagO8VPPe4QOj4FUTdcU/ROnBcVyRBmtANBznx1W",
                    Role = UserRoles.Admin,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 2,
                    Username = "User1",
                    PasswordHash = "$2a$11$oyZpd6ltbGoVcWagO8VPPe4QOj4FUTdcU/ROnBcVyRBmtANBznx1W",
                    Role = UserRoles.User,
                    CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Livekonsert: Coldplay",
                    Description = "En magisk kväll med Coldplay på Friends Arena",
                    Type = EventType.Concert,
                    StartTime = new DateTime(2025, 5, 10, 18, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 5, 10, 21, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 50000
                },
                new Event
                {
                    Id = 2,
                    Name = "Matfestival 2025",
                    Description = "Upptäck smaker från hela världen på en helg fylld med mat",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 6, 15, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 6, 15, 17, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 300
                },
                new Event
                {
                    Id = 3,
                    Name = "Hackathon AI Challenge",
                    Description = "Programmerare tävlar om att skapa den bästa AI-lösningen",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 5, 10, 18, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 5, 10, 21, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 150
                }
            );
        }
    }
}

