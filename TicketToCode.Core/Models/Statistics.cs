namespace TicketToCode.Core.Models;

public record Statistics
{
    public int TotalBookings { get; init; }
    public int TotalEvents { get; init; }
    public int TotalTickets { get; init; }
    public decimal TotalRevenue { get; init; }
} 