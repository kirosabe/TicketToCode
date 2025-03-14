<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Models;
>>>>>>> origin/main

namespace TicketToCode.Api.Endpoints;
public class GetAllEvents : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/events", Handle)
        .WithSummary("Get all events");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        string Description,
        EventType Type,
        DateTime Start,
        DateTime End,
        int MaxAttendees
    );

    //Logic
<<<<<<< HEAD
    private static List<Response> Handle([FromServices] IDatabase db)

=======
    private static async Task<List<Response>> Handle(AppDbContext db)
>>>>>>> origin/main
    {
        var events = await db.Events.ToListAsync();
        return events.Select(item => new Response(
            Id: item.Id,
            Name: item.Name,
            Description: item.Description,
            Type: item.Type,
            Start: item.StartTime,
            End: item.EndTime,
            MaxAttendees: item.MaxAttendees
        )).ToList();
    }
}