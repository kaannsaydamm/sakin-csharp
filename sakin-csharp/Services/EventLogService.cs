namespace sakin_csharp.Models
{
    public class EventLogService
    {
        public int Id { get; set; } // Olayın benzersiz kimliği
        public string EventType { get; set; } // Olay türü
        public string EventMessage { get; set; } // Olay mesajı
        public DateTime Timestamp { get; set; } // Olay zamanı
    }
}