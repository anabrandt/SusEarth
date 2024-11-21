// Controllers/WasteInfoController.cs
using Microsoft.AspNetCore.Mvc;
using SusEarth.API.Models;
using SusEarth.API.Services;
using System.Threading.Tasks;

namespace SusEarth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteInfoController : ControllerBase
    {
        private readonly WasteInfoService _wasteInfoService;

        public WasteInfoController(WasteInfoService wasteInfoService)
        {
            _wasteInfoService = wasteInfoService;
        }

        // POST api/wasteinfo
        [HttpPost]
        public async Task<IActionResult> SubmitWasteInfo([FromBody] WasteInfo wasteInfo)
        {
            if (wasteInfo == null)
            {
                return BadRequest("Informações de lixo eletrônico são necessárias.");
            }

            var result = await _wasteInfoService.SaveWasteInfoAsync(wasteInfo);
            if (result)
            {
                return Ok("Informações de lixo eletrônico enviadas com sucesso.");
            }

            return StatusCode(500, "Erro ao salvar as informações.");
        }
    }
}
