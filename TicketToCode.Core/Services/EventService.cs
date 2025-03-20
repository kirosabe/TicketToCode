using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketToCode.Core.Models;
using TicketToCode.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace TicketToCode.Core.Services
{
    public class EventService
    {
        private readonly AppDbContext _database;

        public EventService(AppDbContext database)
        {
            _database = database;
        }

        public async Task<List<Event>> GetSortedEventsAsync(string? sortOrder = null)
        {
            var eventsQuery = _database.Events.AsQueryable();

            if (string.IsNullOrEmpty(sortOrder))
            {
                return await eventsQuery.ToListAsync();
            }

            if (sortOrder.ToLower() == "asc")
            {
                eventsQuery = eventsQuery.OrderBy(e => e.StartTime);
            }
            else
            {
                eventsQuery = eventsQuery.OrderByDescending(e => e.StartTime);
            }
            var sortedEvents = await eventsQuery.ToListAsync();

            Console.WriteLine($"Sort order: {sortOrder}, Events count: {sortedEvents.Count}");

            return sortedEvents;
        }
    }
}
