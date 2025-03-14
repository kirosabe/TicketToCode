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
        [FromServices] AppDbContext db)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return TypedResults.BadRequest("Invalid username or password");
        }
        context.Response.Cookies.Append("auth", $"{user.Username}:{user.Role}", new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });
        var response = new Response(user.Username, user.Role);
        return TypedResults.Ok(response);
    }
} 