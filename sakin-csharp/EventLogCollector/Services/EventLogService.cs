using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using sakin_csharp.EventLogCollector.Interfaces;
using sakin_csharp.EventLogCollector.Services;
using sakin_csharp.Repositories;
using sakin_csharp.Models;

namespace sakin_csharp.Services
{
    public class EventLogService
    {
        private readonly IEventLogCollector _eventLogCollector;
        private readonly ISystemEventRepository _eventRepository;

        public EventLogService(
            ISystemEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            _eventLogCollector = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? new WindowsEventLogCollector()
                : new LinuxEventLogCollector() as IEventLogCollector;
        }

        public async Task StartEventLogCollectionAsync()
        {
            while (true)
            {
                var events = _eventLogCollector.CollectEvents();
                foreach (var evt in events)
                {
                    await _eventRepository.AddEventAsync(evt);
                }
                await Task.Delay(TimeSpan.FromMinutes(5));
            }
        }
    }
}