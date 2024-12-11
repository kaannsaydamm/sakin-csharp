using Microsoft.EntityFrameworkCore;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.Data
{
    public class SakinDbContext : DbContext
    {
        // Veritabanı bağlamı için yapılandırıcı
        public SakinDbContext(DbContextOptions<SakinDbContext> options) : base(options)
        {
        }

        // Olay günlüğü verilerini tutacak DbSet
        public DbSet<EventLogSystemEvent> SystemEvents { get; set; }
    }
}