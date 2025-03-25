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
        int EventId,
        string Username,
        string FirstName,
        string LastName,
        string Phone,
        string Email,
        int Tickets,
        PaymentMethod PaymentMethod
        );

    public record Response(int BookingId);

    //Logic
    // Changed Task<Ok<Response>> to Task<IResult> to handle BadRequest if user not found
    private static async Task<IResult> Handle(Request request, [FromServices] AppDbContext db)
    {
        // Gets UserId from Username that is passed in the request from the client
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null)
        {
            return TypedResults.BadRequest("User not found.");
        }
        var b = new Booking();

        b.EventId = request.EventId;
        b.UserId = user.Id;
        b.FirstName = request.FirstName;
        b.LastName = request.LastName;
        b.Phone = request.Phone;
        b.Email = request.Email;
        b.Tickets = request.Tickets;
        b.PaymentMethod = request.PaymentMethod;

        db.Bookings.Add(b);
        await db.SaveChangesAsync();
        return TypedResults.Ok(new Response(b.BookingId));
    }
}

