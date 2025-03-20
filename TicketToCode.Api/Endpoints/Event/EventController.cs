using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketToCode.Core.Services;

namespace TicketToCode.Api.Endpoints.Events
{
    public class EventController : ControllerBase
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService) 
        {
            _eventService = eventService;
        }

        public async Task<ActionResult<IEnumerable<TicketToCode.Core.Models.Event>>> GetEvents(string sortOrder = "asc")
        {
            var events = await _eventService.GetSortedEventsAsync(sortOrder);
            return Ok(events);
        }
    }
}
