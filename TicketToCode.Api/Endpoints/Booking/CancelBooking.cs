using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TicketToCode.Api.Endpoints;

public class CancelBooking : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/bookings/{id}/cancel", Handle)
        .WithSummary("Cancel booking");

    private static async Task<IResult> Handle(int id, [FromServices] AppDbContext db)
    {
        var booking = await db.Bookings.FindAsync(id);
        if (booking == null)
        {
            return TypedResults.NotFound(new { Message = "Booking not found" });
        }

        db.Bookings.Remove(booking);
        await db.SaveChangesAsync();
        return TypedResults.Ok(new { Message = "Your booking was ssuccessfully canceled" });
    }
}
