using System.ComponentModel.DataAnnotations;

namespace TicketToCode.Core.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int EventId { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Select at least one ticket to continue")]
    public int Tickets { get; set; } = 1;
    [Required]
    public PaymentMethod PaymentMethod { get; set; }
}
public enum PaymentMethod
{
    CreditCard = 0,
    Swish,
    Invoice
}