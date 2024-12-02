using System.Collections.Generic;
using sakin_csharp.EventLogCollector.Models;

namespace sakin_csharp.EventLogCollector.Interfaces
{
    public interface IEventLogCollector
    {
        List<SystemEvent> CollectEvents(string logName);
        void WriteEventToFile(SystemEvent systemEvent);
    }
}