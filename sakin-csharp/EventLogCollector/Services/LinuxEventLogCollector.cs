using System;
using sakin_csharp.EventLogCollector.Interfaces;

namespace sakin_csharp.EventLogCollector.Services
{
    // Linux sistemleri için olay toplama servisi
    public class LinuxEventLogCollector : IEventLogCollector
    {
        public void CollectEvents()
        {
            // Linux olaylarını toplama işlemi
            Console.WriteLine("Linux olayları toplanıyor...");
        }
    }
}