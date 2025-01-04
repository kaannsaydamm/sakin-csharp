using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sakin_csharp.Data;
using sakin_csharp.Models;

namespace sakin_csharp.Services
{
    public class NetworkPacketService
    {
        private readonly SakinDbContext _context;

        public NetworkPacketService(SakinDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NetworkPacket>> GetAllPacketsAsync()
        {
            return await _context.NetworkPackets.ToListAsync();
        }

        public async Task AddPacketAsync(NetworkPacket packet)
        {
            _context.NetworkPackets.Add(packet);
            await _context.SaveChangesAsync();
        }
    }
}
