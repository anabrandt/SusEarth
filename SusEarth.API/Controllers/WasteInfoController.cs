using Microsoft.AspNetCore.Mvc;
using SusEarth.API.Models;
using SusEarth.API.Services;
using SusEarth.API.Services.CEP;
using System.Threading.Tasks;

namespace SusEarth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteInfoController : ControllerBase
    {
        private readonly WasteInfoService _wasteInfoService;
        private readonly ICEPService _cepService;

        public WasteInfoController(WasteInfoService wasteInfoService, ICEPService cepService)
        {
            _wasteInfoService = wasteInfoService;
            _cepService = cepService;
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

        // GET api/wasteinfo/find-cep/{cep}
        [HttpGet("find-cep/{cep}")]
        public async Task<ActionResult<AddressResponse>> GetAddressByCep(string cep)
        {
            var address = await _cepService.FindCEP(cep);

            if (address == null)
            {
                return NotFound("Endereço não encontrado.");
            }


            return Ok(address);
        }
    }
}
