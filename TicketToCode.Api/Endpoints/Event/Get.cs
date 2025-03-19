﻿using Microsoft.AspNetCore.Mvc;

namespace TicketToCode.Api.Endpoints;
public class GetEvent : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/events/{id}", Handle)
        .WithSummary("Get event");

    // Request and Response types
    public record Request(int Id);

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
            MaxAttendees: ev.MaxAttendees
            );

        return response;
    }
}