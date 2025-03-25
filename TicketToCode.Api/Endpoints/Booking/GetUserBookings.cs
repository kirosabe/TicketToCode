using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Data;
using TicketToCode.Core.Models;

namespace TicketToCode.Api.Endpoints;

public class GetUserBookings : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/users/{username}/bookings", Handle)
        .WithSummary("Get all bookings for a user by username");

    public record Response(
        int BookingId,
        string? EventName,
        int Tickets,
        string FirstName,
        string LastName,
        DateTime? Start

    );
    // Logic
    private static async Task<IResult> Handle(string username, [FromServices] AppDbContext db)
    {
        var user = await db.Users
            .Include(u => u.Bookings)
            .ThenInclude(b => b.Event)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user is null)
            return Results.NotFound("User not found");

        var result = user.Bookings.Select(b => new Response(
            b.BookingId,
            b.Event?.Name,
            b.Tickets,
            b.FirstName,
            b.LastName,
            b.Event?.StartTime
        ));

        return Results.Ok(result);
    }
}
