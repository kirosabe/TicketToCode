using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Models;

namespace TicketToCode.Api.Endpoints;

public class GetAllBookings : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bookings", Handle)
        .WithSummary("Get all bookings");

    private static async Task<Ok<List<Booking>>> Handle([FromServices] AppDbContext db)
    {
        var bookings = await db.Bookings.ToListAsync();
        return TypedResults.Ok(bookings);
    }
} 