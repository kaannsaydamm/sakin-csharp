using System.Collections.Generic;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.Repositories
{
    // Olay deposu arayüzü
    public interface ISystemEventRepository
    {
        IEnumerable<EventLogSystemEvent> GetAllEvents(); // Tüm olayları getir
        void AddEvent(EventLogSystemEvent systemEvent); // Yeni bir olayı ekle
    }
}