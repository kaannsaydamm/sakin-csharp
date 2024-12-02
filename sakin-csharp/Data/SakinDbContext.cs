using Microsoft.EntityFrameworkCore;
using sakin_csharp.Models;

namespace sakin_csharp.Data
{
    public class SakinDbContext : DbContext
    {
        public SakinDbContext(DbContextOptions<SakinDbContext> options) 
            : base(options) {}

        public DbSet<SystemEvent> SystemEvents { get; set; }
    }
}