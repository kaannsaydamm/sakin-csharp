using System;

namespace sakin_csharp.Models
{
    // Sistem olaylarını temsil eden model
    public class SystemEvent
    {
        public int Id { get; set; } // Olayın benzersiz kimliği
        public string EventType { get; set; } = null!; // Olay türü
        public string Message { get; set; } = null!; // Olay mesajı
        public DateTime Timestamp { get; set; } // Olay zaman damgası
    }
}