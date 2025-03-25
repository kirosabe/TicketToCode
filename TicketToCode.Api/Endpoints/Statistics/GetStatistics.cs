using Microsoft.AspNetCore.Mvc;
using TicketToCode.Core.Models;

namespace TicketToCode.Api.Endpoints;

public class GetStatistics : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/statistics", Handle)
        .WithSummary("Get event statistics");

    private static async Task<Ok<Statistics>> Handle([FromServices] AppDbContext db)
    {
        var totalBookings = await db.Bookings.CountAsync();
        var totalEvents = await db.Events.CountAsync();
        var totalTickets = await db.Bookings.SumAsync(b => b.Tickets);
        var totalRevenue = await db.Bookings
            .Join(db.Events, b => b.EventId, e => e.Id, (b, e) => b.Tickets * e.Price)
            .SumAsync();

        var response = new Statistics
        {
            TotalBookings = totalBookings,
            TotalEvents = totalEvents,
            TotalTickets = totalTickets,
            TotalRevenue = totalRevenue
        };

        return TypedResults.Ok(response);
    }
} 