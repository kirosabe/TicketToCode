﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketToCode.Core.Data;

#nullable disable

namespace TicketToCode.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250325140206_AddEventNavigationToBooking")]
    partial class AddEventNavigationToBooking
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketToCode.Core.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tickets")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TicketToCode.Core.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxAttendees")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "En magisk kväll med Coldplay på Friends Arena",
                            EndTime = new DateTime(2025, 5, 10, 21, 0, 0, 0, DateTimeKind.Utc),
                            MaxAttendees = 50000,
                            Name = "Livekonsert: Coldplay",
                            Price = 2000m,
                            StartTime = new DateTime(2025, 5, 10, 18, 0, 0, 0, DateTimeKind.Utc),
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Upptäck smaker från hela världen på en helg fylld med mat",
                            EndTime = new DateTime(2025, 6, 15, 17, 0, 0, 0, DateTimeKind.Utc),
                            MaxAttendees = 300,
                            Name = "Matfestival 2025",
                            Price = 200m,
                            StartTime = new DateTime(2025, 6, 15, 9, 0, 0, 0, DateTimeKind.Utc),
                            Type = 3
                        },
                        new
                        {
                            Id = 3,
                            Description = "Programmerare tävlar om att skapa den bästa AI-lösningen",
                            EndTime = new DateTime(2025, 5, 10, 21, 0, 0, 0, DateTimeKind.Utc),
                            MaxAttendees = 150,
                            Name = "Hackathon AI Challenge",
                            Price = 150m,
                            StartTime = new DateTime(2025, 5, 10, 18, 0, 0, 0, DateTimeKind.Utc),
                            Type = 3
                        });
                });

            modelBuilder.Entity("TicketToCode.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PasswordHash = "$2a$11$oyZpd6ltbGoVcWagO8VPPe4QOj4FUTdcU/ROnBcVyRBmtANBznx1W",
                            Role = "Admin",
                            Username = "Admin1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PasswordHash = "$2a$11$oyZpd6ltbGoVcWagO8VPPe4QOj4FUTdcU/ROnBcVyRBmtANBznx1W",
                            Role = "User",
                            Username = "User1"
                        });
                });

            modelBuilder.Entity("TicketToCode.Core.Models.Booking", b =>
                {
                    b.HasOne("TicketToCode.Core.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketToCode.Core.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketToCode.Core.Models.User", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
