using Microsoft.EntityFrameworkCore;
using sakin_csharp.Models;

namespace sakin_csharp.Data
{
    public class SakinDbContext : DbContext
    {
        public SakinDbContext(DbContextOptions<SakinDbContext> options) : base(options)
        {
        }

        public DbSet<NetworkPacket> NetworkPackets { get; set; } = null!;
        public DbSet<SystemEvent> SystemEvents { get; set; } = null!;
    }
}