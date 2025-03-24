using TicketToCode.Core.Data;
using TicketToCode.Core.Models;

namespace TicketToCode.Api.Services;

public interface IAuthService
{
    User? Login(string username, string password);
    User? Register(string username, string password);
}

// TODO: Implement better auth
/// <summary>
/// Simple auth service to enable registering and login in, should be replaced before release
/// </summary>
public class AuthService : IAuthService
{
    private readonly AppDbContext _database;

    public AuthService(AppDbContext database)
    {
        _database = database;
    }

    public User? Login(string username, string password)
    {
        var user = _database.Users.FirstOrDefault(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }

    public User? Register(string username, string password)
    {
        if (_database.Users.Any(u => u.Username == username))
        {
            return null;
        }

        var user = new User(username, BCrypt.Net.BCrypt.HashPassword(password));

        _database.Users.Add(user);
        return user;
    }
} 