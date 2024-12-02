using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sakin_csharp.Data;
using sakin_csharp.Models;

namespace sakin_csharp.Repositories
{
    public class SystemEventRepository : ISystemEventRepository
    {
        private readonly SakinDbContext _context;

        public SystemEventRepository(SakinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemEvent>> GetAllEventsAsync()
        {
            return await _context.SystemEvents
                .OrderByDescending(e => e.Timestamp)
                .ToListAsync();
        }

        public async Task<SystemEvent> AddEventAsync(SystemEvent systemEvent)
        {
            await _context.SystemEvents.AddAsync(systemEvent);
            await _context.SaveChangesAsync();
            return systemEvent;
        }

        public async Task<IEnumerable<SystemEvent>> GetEventsByTypeAsync(string eventType)
        {
            return await _context.SystemEvents
                .Where(e => e.EventType == eventType)
                .ToListAsync();
        }
    }
}