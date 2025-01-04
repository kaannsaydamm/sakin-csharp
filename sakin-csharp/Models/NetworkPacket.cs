using System;

namespace sakin_csharp.Models
{
    public class NetworkPacket
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string SourceAddress { get; set; } = null!;
        public string DestinationAddress { get; set; } = null!;
        public string Protocol { get; set; } = null!;
        public int Length { get; set; }
    }
}
