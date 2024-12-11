using System;

namespace sakin_csharp.EventLogCollector.Models
{
    public class SystemEvent
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
    }
}