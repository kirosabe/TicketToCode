using TicketToCode.Api.Services;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace TicketToCode.Api.Endpoints.Auth;

public class Login : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/auth/login", Handle)
     .WithSummary("Login with username and password")
     .AllowAnonymous() 
     .Accepts<Request>("application/json")
     .Produces<Response>(StatusCodes.Status200OK)
     .Produces<string>(StatusCodes.Status400BadRequest);

    // Models
    public record Request(string Username, string Password);
    public record Response(string Username, string Role);

    // Logic
    private static async Task<Results<Ok<Response>, BadRequest<string>>> Handle(
        HttpContext context,
        [FromBody] Request request,
        [FromServices] IAuthService authService)
    {
        var user = authService.Login(request.Username, request.Password);
        if (user == null)
        {
            return TypedResults.BadRequest("Invalid username or password");
        }
        var response = new Response(user.Username, user.Role);
        return TypedResults.Ok(response);
    }
} 