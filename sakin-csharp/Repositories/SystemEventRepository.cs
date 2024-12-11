using System.Collections.Generic;
using System.Linq;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.Repositories
{
    // Olay deposu implementasyonu
    public class SystemEventRepository : ISystemEventRepository
    {
        private readonly List<EventLogSystemEvent> _events = new List<EventLogSystemEvent>(); // Olayları tutacak liste

        // Tüm olayları getir
        public IEnumerable<EventLogSystemEvent> GetAllEvents()
        {
            return _events; // Olay listesini döndür
        }

        // Yeni bir olayı ekle
        public void AddEvent(EventLogSystemEvent systemEvent)
        {
            _events.Add(systemEvent); // Olayı listeye ekle
        }
    }
}