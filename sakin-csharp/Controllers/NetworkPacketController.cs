using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sakin_csharp.Models;
using sakin_csharp.Services;

namespace sakin_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NetworkPacketController : ControllerBase
    {
        private readonly NetworkPacketService _service;

        public NetworkPacketController(NetworkPacketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPackets()
        {
            var packets = await _service.GetAllPacketsAsync();
            return Ok(packets);
        }

        [HttpPost]
        public async Task<IActionResult> AddPacket(NetworkPacket packet)
        {
            await _service.AddPacketAsync(packet);
            return Ok();
        }
    }
}
