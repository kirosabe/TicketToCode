namespace TicketToCode.Core.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; } = string.Empty; // Default value to avoid null reference exception
    public string? PasswordHash { get; set; } = string.Empty; // Default value to avoid null reference exception
     public string Role { get; set; } = UserRoles.User; // Default role
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    // List of bookings for the user for entity framework to handle
    public List<Booking> Bookings { get; set; } = new();
    public User() { }

    public User(string name, string pwd)
    {
        Username = name;
        PasswordHash = pwd;
    }
}

// Static class to define roles
public static class UserRoles
{
    public const string Admin = "Admin";
    public const string User = "User";

} 