using System;
using sakin_csharp.EventLogCollector.Interfaces;

namespace sakin_csharp.EventLogCollector.Services
{
    // Windows sistemleri için olay toplama servisi
    public class WindowsEventLogCollector : IEventLogCollector
    {
        public void CollectEvents()
        {
            // Windows olaylarını toplama işlemi
            Console.WriteLine("Windows olayları toplanıyor...");
        }
    }
}