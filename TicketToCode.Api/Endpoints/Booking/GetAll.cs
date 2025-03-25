using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Models;

namespace TicketToCode.Api.Endpoints;

public class GetAllBookings : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bookings", Handle)
        .WithSummary("Get all bookings");

    public record Response(
        int BookingId,
        string EventName,
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        int Tickets,
        PaymentMethod PaymentMethod
    );

    private static async Task<Ok<List<Response>>> Handle([FromServices] AppDbContext db)
    {
        var bookings = await db.Bookings
            .Include(b => b.Event)
            .Select(b => new Response(
                b.BookingId,
                b.Event.Name,
                b.FirstName,
                b.LastName,
                b.Email,
                b.Phone,
                b.Tickets,
                b.PaymentMethod
            ))
            .ToListAsync();

        return TypedResults.Ok(bookings);
    }
} 