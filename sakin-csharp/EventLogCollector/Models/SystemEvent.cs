using System;
using System.ComponentModel.DataAnnotations;

namespace sakin_csharp.Models
{
    public class SystemEvent
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string EventType { get; set; }
        public string Message { get; set; }
        public int EventId { get; set; }
        public string Platform { get; set; }
        public double Severity { get; set; }
    }
}