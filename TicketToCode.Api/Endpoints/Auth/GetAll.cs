
namespace TicketToCode.Api.Endpoints.Auth;

public class GetAllUsers : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/auth/users", Handle)
        .WithSummary("Get all users")
        .Produces<List<Response>>(StatusCodes.Status200OK);

    // Response Model
    public record Response(int Id, string Username, string Role);

    // Logic
    private static async Task<Ok<List<Response>>> Handle([FromServices] AppDbContext db)
    {
        var users = await db.Users
            .Select(u => new Response(u.Id, u.Username, u.Role))
            .ToListAsync();

        return TypedResults.Ok(users);
    }
}
