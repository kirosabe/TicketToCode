using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TicketToCode.Api.Endpoints;

public class UpdateEvent : IEndpoint
{
    // Mapping för uppdatering av event
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/events/{id}", Handle)
        .WithSummary("Update an existing event");

    // Request-typ för att ta emot data
    public record Request(
        string Name,
        string Description,
        EventType Type,
        DateTime Start,
        DateTime End,
        int MaxAttendees
    );

    // Response-typ
    public record Response(int Id, string Message);

    // Uppdateringslogik
    private static async Task<IResult> Handle(int id, Request request, [FromServices] AppDbContext db)
    {
        // Leta upp eventet i databasen
        var ev = await db.Events.FindAsync(id);
        if (ev == null)
        {
            return TypedResults.NotFound(new { Message = "Event not found" });
        }

        // Uppdatera eventets fält
        ev.Name = request.Name;
        ev.Description = request.Description;
        ev.Type = request.Type;
        ev.StartTime = request.Start;
        ev.EndTime = request.End;
        ev.MaxAttendees = request.MaxAttendees;

        // Spara ändringar
        await db.SaveChangesAsync();

        return TypedResults.Ok(new Response(ev.Id, "Event updated successfully"));
    }
}
