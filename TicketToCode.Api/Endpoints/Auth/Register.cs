using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TicketToCode.Api.Services;

namespace TicketToCode.Api.Endpoints.Auth;

public class Register : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/auth/register", Handle)
        .WithSummary("Register a new user")
        .AllowAnonymous()
         .Accepts<Request>("application/json")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status400BadRequest);

    // Models
    public record Request(string Username, string Password);
    public record Response(string Username, string Role);

    // Logic
    private static async Task<Results<Ok<Response>, BadRequest<string>>> Handle(
    [FromBody] Request request,
    [FromServices] AppDbContext db)
    {
        var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (existingUser != null)
        {
            return TypedResults.BadRequest("Username already exists");
        }

        var newUser = new User
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = UserRoles.User 
        };

        db.Users.Add(newUser);
        await db.SaveChangesAsync();

        return TypedResults.Ok(new Response(newUser.Username, newUser.Role));
    }
}