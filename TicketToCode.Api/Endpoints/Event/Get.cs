﻿using Microsoft.AspNetCore.Mvc;

namespace TicketToCode.Api.Endpoints;
public class GetEvent : IEndpoint
{
    
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/events/{id}", Handle)
        .WithSummary("Get event");

    
    public record Request(int Id);

    public record Response(
        int Id,
        string Name,
        string Description,
        EventType Type,
        DateTime Start,
        DateTime End,
        int MaxAttendees,
        decimal Price
    );


    //Logic
    private static Response Handle([AsParameters] Request request, [FromServices] AppDbContext db)

    {
        var ev = db.Events.FirstOrDefault(ev => ev.Id == request.Id);

        var response = new Response(
            Id: ev.Id,
            Name: ev.Name,
            Description: ev.Description,
            Type: ev.Type,
            Start: ev.StartTime,
            End: ev.EndTime,
            MaxAttendees: ev.MaxAttendees,
            Price: ev.Price
            );

        return response;
    }
}