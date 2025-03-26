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
        public DbSet<Booking> Bookings { get; set; }

        // Model for test data seeding
        // To use this model, add the following code in CMD from TicketToCode.API where appsettings.json is:
        // dotnet ef database update --project ../TicketToCode.Core --startup-project .


        // Use this from API as startpoint to add new migrations
        // dotnet ef migrations add NAME --project ../TicketToCode.Core --startup-project .

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
                    MaxAttendees = 50000,
                    Price = 2000
                },
                new Event
                {
                    Id = 2,
                    Name = "Matfestival 2025",
                    Description = "Upptäck smaker från hela världen på en helg fylld med mat",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 6, 15, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 6, 15, 17, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 300,
                    Price = 200

                },
                new Event
                {
                    Id = 3,
                    Name = "Hackathon AI Challenge",
                    Description = "Programmerare tävlar om att skapa den bästa AI-lösningen",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 5, 10, 18, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 5, 10, 21, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 150,
                    Price = 150
                },
                new Event
                {
                    Id = 4,
                    Name = "Sommarfestival: Göteborg Sounds",
                    Description = "En heldag med musik, mat och aktiviteter vid vattnet i Göteborg.",
                    Type = EventType.Festival,
                    StartTime = new DateTime(2025, 7, 6, 14, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 7, 6, 23, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 20000,
                    Price = 750
                },
                new Event
                {
                    Id = 5,
                    Name = "Stand-up Night med Petra Mede",
                    Description = "Skrattgaranti när Petra Mede bjuder på humor i världsklass.",
                    Type = EventType.Theatre,
                    StartTime = new DateTime(2025, 9, 12, 19, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 12, 21, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 800,
                    Price = 450
                },
                new Event
                {
                    Id = 6,
                    Name = "Operakväll: Carmen på Kungliga Operan",
                    Description = "En klassisk föreställning av Carmen i storslagen miljö.",
                    Type = EventType.Theatre,
                    StartTime = new DateTime(2025, 11, 3, 18, 30, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 11, 3, 21, 30, 0, DateTimeKind.Utc),
                    MaxAttendees = 1200,
                    Price = 650
                },
                new Event
                {   
                    Id = 7,
                    Name = "Gaming Expo Stockholm 2025",
                    Description = "Testa nya spel, träffa influencers och upplev e-sport live.",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 8, 22, 10, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 8, 22, 18, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 10000,
                    Price = 300
                },
                new Event
                {
                    Id = 8,
                    Name = "Julmarknad i Gamla Stan",
                    Description = "Traditionell julmarknad med hantverk, glögg och julstämning.",
                    Type = EventType.Other,
                    StartTime = new DateTime(2025, 12, 14, 11, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 12, 14, 17, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 5000,
                    Price = 0
                    },
                new Event
                {
                    Id = 9,
                    Name = "Rockkväll med Ghost",
                    Description = "Upplev Ghosts mörka rockshow live i Globen.",
                    Type = EventType.Concert,
                    StartTime = new DateTime(2025, 10, 18, 20, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 10, 18, 23, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 16000,
                    Price = 950
                },
                new Event
                {
                    Id = 10,
                    Name = "Jazz under Stjärnorna",
                    Description = "En intim kväll med livemusik i Hagaparken.",
                    Type = EventType.Concert,
                    StartTime = new DateTime(2025, 7, 20, 19, 30, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 7, 20, 22, 30, 0, DateTimeKind.Utc),
                    MaxAttendees = 1000,
                    Price = 300
                },
                new Event
                {
                    Id = 11,
                    Name = "Street Food Festival Malmö",
                    Description = "Tre dagar med food trucks, live-DJs och god stämning.",
                    Type = EventType.Festival,
                    StartTime = new DateTime(2025, 8, 1, 12, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 8, 3, 22, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 8000,
                    Price = 100
                },
                new Event
                {
                    Id = 12,
                    Name = "Skärgårdsfestivalen Vaxholm",
                    Description = "Musik, segling och skärgårdskultur för hela familjen.",
                    Type = EventType.Festival,
                    StartTime = new DateTime(2025, 6, 29, 11, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 6, 29, 20, 0, 0, DateTimeKind.Utc),
                    MaxAttendees = 3000,
                    Price = 250
                }
            );
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

