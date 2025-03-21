using TicketToCode.Core.Models;
//Saves state of booking to shows it later in confirmation
public class BookingState
{
    public Booking? CurrentBooking { get; set; }
}
