using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TicketToCode.Api.Endpoints;
public class CreateBooking : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bookings", Handle)
        .WithSummary("Create booking");
    public record Request(
        int BookingId,
        int EventId,
        string FirstName,
        string LastName,
        string Phone,
        string Email,
        int Tickets,
        PaymentMethod PaymentMethod
        );


    public record Response(int id);

    //Logic
    private static async Task<Ok<Response>> Handle(Request request, [FromServices] AppDbContext db)
    {
        var b = new Booking();

        b.BookingId = request.BookingId;
        b.EventId = request.EventId;
        b.FirstName = request.FirstName;
        b.LastName = request.LastName;
        b.Phone = request.Phone;
        b.Email = request.Email;
        b.Tickets = request.Tickets;
        b.PaymentMethod = request.PaymentMethod;

        //db.Bookings.Add(b);
        await db.SaveChangesAsync();
        return TypedResults.Ok(new Response(b.BookingId));
    }
}

