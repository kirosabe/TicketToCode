using Microsoft.AspNetCore.Mvc;

namespace TicketToCode.Api.Endpoints;
public class CreateEvent : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/events", Handle)
        .WithSummary("Create event");

    // Request and Response types
    // Why do we need these? check this video if you are not sure
    // https://youtu.be/xtpPspNdX58?si=GJBUxMzeR2ZJ5Fg_
    public record Request(
        string Name,
        string Description,
        EventType Type,
        DateTime Start,
        DateTime End,
        int MaxAttendees,
        decimal Price
        );
    public record Response(int id);

    //Logic
    private static async Task<Ok<Response>> Handle(Request request, [FromServices] AppDbContext db)
    {
        
        var ev = new Event();

        ev.Name = request.Name;
        ev.Description = request.Description;
        ev.Type = request.Type;
        ev.StartTime = request.Start;
        ev.EndTime = request.End;
        ev.MaxAttendees = request.MaxAttendees;
        ev.Price = request.Price;


       
        db.Events.Add(ev);
        await db.SaveChangesAsync();
        return TypedResults.Ok(new Response(ev.Id));
    }
}

