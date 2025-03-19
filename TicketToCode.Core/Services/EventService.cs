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

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _database.Events.ToListAsync();
        }

        public async Task<List<Event>> GetSortedEventsAsync(string sortOrder)
        {
            var eventsQuery = _database.Events.AsQueryable();

            if (sortOrder?.ToLower() == "asc")
            {
                eventsQuery = eventsQuery.OrderBy(e => e.StartTime);
            }
            else if (sortOrder?.ToLower() == "desc")
            {
                eventsQuery = eventsQuery.OrderByDescending(e => e.StartTime);
            }

            return await eventsQuery.ToListAsync();
        }
    }
}
