using System.Collections.Generic;
using System.Threading.Tasks;
using sakin_csharp.Models;

namespace sakin_csharp.Repositories
{
    public interface ISystemEventRepository
    {
        Task<IEnumerable<SystemEvent>> GetAllEventsAsync();
        Task<SystemEvent> AddEventAsync(SystemEvent systemEvent);
        Task<IEnumerable<SystemEvent>> GetEventsByTypeAsync(string eventType);
    }
}