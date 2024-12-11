using Microsoft.AspNetCore.Mvc;
using sakin_csharp.EventLogCollector;

namespace sakin_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // Olay günlüğü ile ilgili API denetleyicisi
    public class EventLogController : ControllerBase
    {
        private readonly EventLogService _eventLogService; // Olay günlüğü servisi

        public EventLogController(EventLogService eventLogService)
        {
            _eventLogService = eventLogService; // Bağımlılık enjeksiyonu ile olay günlüğü servisini al
        }

          // Tüm olayları getiren API metodu
        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = _eventLogService.GetAllEvents(); // Tüm olayları al
            return Ok(events); // Olayları döndür
        }
    }
}