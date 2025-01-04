using Microsoft.EntityFrameworkCore;
using sakin_csharp.Models;

namespace sakin_csharp.Data
{
    public class NetworkPacketDbContext : DbContext
    {
        public DbSet<NetworkPacket> NetworkPackets { get; set; }

        public NetworkPacketDbContext(DbContextOptions<NetworkPacketDbContext> options)
            : base(options)
        {
            // Initialize NetworkPackets to avoid CS8618 warning
            NetworkPackets = Set<NetworkPacket>();
        }
    }
}
