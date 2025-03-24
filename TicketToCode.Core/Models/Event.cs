namespace TicketToCode.Core.Models;
public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = "New event";
    public string Description { get; set; } = string.Empty;
    public EventType Type { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MaxAttendees { get; set; }
    public decimal Price {  get; set; }

    public Event()
    {
        
    }
    public Event(string name, string description, EventType type, DateTime startTime, DateTime endTime, int maxAttendees, decimal price)
    {
        Name = name;
        Description = description;
        Type = type;
        StartTime = startTime;
        EndTime = endTime;
        MaxAttendees = maxAttendees;
        Price = price;
    }
}

public enum EventType
{
    Concert = 0,
    Festival,
    Theatre,
    Other
}