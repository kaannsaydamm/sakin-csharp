using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sakin_csharp.Repositories;
using sakin_csharp.Models;
using System.Collections.Generic;

namespace sakin_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventLogController : ControllerBase
    {
        private readonly ISystemEventRepository _eventRepository;

        public EventLogController(ISystemEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: api/eventlog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemEvent>>> GetAllEvents()
        {
            try
            {
                var events = await _eventRepository.GetAllEventsAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Event log toplama hatası: {ex.Message}");
            }
        }

        // GET: api/eventlog/type/{eventType}
        [HttpGet("type/{eventType}")]
        public async Task<ActionResult<IEnumerable<SystemEvent>>> GetEventsByType(string eventType)
        {
            try
            {
                var events = await _eventRepository.GetEventsByTypeAsync(eventType);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Event log toplama hatası: {ex.Message}");
            }
        }
    }
}