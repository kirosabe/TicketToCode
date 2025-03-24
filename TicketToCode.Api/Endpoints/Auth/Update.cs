

namespace TicketToCode.Api.Endpoints.Auth;

public class UpdateUser : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPut("/auth/users/{id}", Handle)
        .WithSummary("Update user information")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

    public record Request(string Username, string Role);
    public record Response(int Id, string Username, string Role);

    private static async Task<Results<Ok<Response>, NotFound<string>>> Handle(
        int id,
        [FromBody] Request request,
        [FromServices] AppDbContext db)
    {
        var user = await db.Users.FindAsync(id);
        if (user == null)
        {
            return TypedResults.NotFound("User not found");
        }

        user.Username = request.Username;
        user.Role = request.Role;

        await db.SaveChangesAsync();

        return TypedResults.Ok(new Response(user.Id, user.Username, user.Role));
    }
}
