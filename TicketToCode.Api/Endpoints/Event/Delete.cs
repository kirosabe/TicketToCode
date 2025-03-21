using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TicketToCode.Api.Endpoints;

public class DeleteEvent : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/events/{id}", Handle)
        .WithSummary("Delete an event");

    private static async Task<IResult> Handle(int id, [FromServices] AppDbContext db)
    {
        var ev = await db.Events.FindAsync(id);
        if (ev == null)
        {
            return TypedResults.NotFound(new { Message = "Event not found" });
        }

        db.Events.Remove(ev);
        await db.SaveChangesAsync();
        return TypedResults.Ok(new { Message = "Event deleted successfully" });
    }
}
