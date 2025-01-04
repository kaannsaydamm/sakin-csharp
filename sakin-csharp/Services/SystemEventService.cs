using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sakin_csharp.Data;
using sakin_csharp.Models;

namespace sakin_csharp.Services
{
    public class SystemEventService
    {
        private readonly SakinDbContext _context;

        public SystemEventService(SakinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemEvent>> GetAllEventsAsync()
        {
            return await _context.SystemEvents.ToListAsync();
        }

        public async Task AddEventAsync(SystemEvent systemEvent)
        {
            _context.SystemEvents.Add(systemEvent);
            await _context.SaveChangesAsync();
        }
    }
}
