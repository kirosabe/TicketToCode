using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TicketToCode.Api.Endpoints;

public class UpdateEvent : IEndpoint
{
    // Mapping för uppdatering av event
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/events/{id}", Handle)
        .WithSummary("Update an existing event");

    public record Request(
        string Name,
        string Description,
        EventType Type,
        DateTime Start,
        DateTime End,
        int MaxAttendees,
        decimal Price
    );

    
    public record Response(int Id, string Message);

  
    private static async Task<IResult> Handle(int id, Request request, [FromServices] AppDbContext db)
    {
        var ev = await db.Events.FindAsync(id);
        if (ev == null)
        {
            return TypedResults.NotFound(new { Message = "Event not found" });
        }

        
        ev.Name = request.Name;
        ev.Description = request.Description;
        ev.Type = request.Type;
        ev.StartTime = request.Start;
        ev.EndTime = request.End;
        ev.MaxAttendees = request.MaxAttendees;
        ev.Price = request.Price;

        await db.SaveChangesAsync();

        return TypedResults.Ok(new Response(ev.Id, "Event updated successfully"));
    }
}
