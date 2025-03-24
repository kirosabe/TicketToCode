

namespace TicketToCode.Api.Endpoints.Auth;

public class DeleteUser : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/auth/users/{id}", Handle)
        .WithSummary("Delete a user")
        .Produces<string>(StatusCodes.Status200OK)
        .Produces<string>(StatusCodes.Status404NotFound);

    private static async Task<Results<Ok<string>, NotFound<string>>> Handle(
        int id,
        [FromServices] AppDbContext db)
    {
        var user = await db.Users.FindAsync(id);
        if (user == null)
        {
            return TypedResults.NotFound("User not found");
        }

        db.Users.Remove(user);
        await db.SaveChangesAsync();

        return TypedResults.Ok($"User {id} deleted successfully");
    }
}
