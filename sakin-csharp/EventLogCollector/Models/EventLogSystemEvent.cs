using System;

namespace sakin_csharp.EventLogCollector.Models
{
    // Olay günlüğü sistemi için model
    public class EventLogSystemEvent
    {
        public int Id { get; set; } // Olayın benzersiz kimliği
        public DateTime Timestamp { get; set; } // Olayın zaman damgası
        public string Message { get; set; } // Olay mesajı
        public string Source { get; set; } // Olay kaynağı
    }
}