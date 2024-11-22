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

        /// <summary>
        /// Envia informações sobre lixo eletrônico.
        /// </summary>
        /// <remarks>
        /// Exemplo de Solicitação:
        /// 
        ///     POST api/wasteinfo
        ///     {
        ///         "wasteType": "Pilhas",
        ///         "description": "Pilhas e baterias usadas",
        ///         "disposalLocation": "Estação Paulista",
        ///         "address": "Av. Paulista, 1106 - São Paulo - SP"
        ///     }
        /// </remarks>
        /// <param name="wasteInfo">Informações sobre o lixo eletrônico a ser enviado</param>
        /// <response code="200">Informações de lixo eletrônico enviadas com sucesso</response>
        /// <response code="400">Informações de lixo eletrônico inválidas ou ausentes</response>
        /// <response code="500">Erro interno ao salvar as informações</response>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Retorna o endereço baseado no CEP fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de Solicitação:
        /// 
        ///     GET api/wasteinfo/find-cep/01001-000
        /// </remarks>
        /// <param name="cep">O CEP para buscar o endereço</param>
        /// <response code="200">Retorna o endereço correspondente ao CEP</response>
        /// <response code="404">Nenhum endereço encontrado para o CEP fornecido</response>
        /// <response code="500">Erro interno ao buscar o endereço</response>
        [HttpGet("find-cep/{cep}")]
        [ProducesResponseType(typeof(AddressResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
