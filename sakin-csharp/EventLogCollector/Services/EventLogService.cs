using System.Collections.Generic;
using System.Threading.Tasks;
using sakin_csharp.EventLogCollector.Models;
using sakin_csharp.Repositories;

namespace sakin_csharp.EventLogCollector
{
    // Olay günlüğü toplama ve yönetim servisi
    public class EventLogService
    {
        private readonly ISystemEventRepository _repository; // Olay deposu

        public EventLogService(ISystemEventRepository repository)
        {
            _repository = repository; // Bağımlılık enjeksiyonu ile olay deposunu al
        }

        // Olay günlüğü toplama işlemini başlat
        public async Task StartEventLogCollectionAsync()
        {
            // Olay günlüğü toplama işlemleri burada yapılacak
            Console.WriteLine("Event log collection started...");
        }

        // Tüm olayları getir
        public IEnumerable<EventLogSystemEvent> GetAllEvents()
        {
            return _repository.GetAllEvents(); // Olay deposundan tüm olayları al
        }

        // Yeni bir olayı kaydet
        public void LogEvent(EventLogSystemEvent systemEvent)
        {
            _repository.AddEvent(systemEvent); // Olay deposuna yeni olayı ekle
        }
    }
}