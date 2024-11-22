using Microsoft.AspNetCore.Mvc;
using SusEarth.Models;
using SusEarth.Services;
using System.Text.Json;

namespace SusEarth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WasteInfoController : ControllerBase
    {
        private readonly MetroService _metroService;

        public WasteInfoController()
        {
            _metroService = new MetroService();
        }

        [HttpGet("findNearestMetro/{cep}")]
        public async Task<IActionResult> FindNearestMetro(string cep)
        {
            var address = await GetAddressFromCep(cep); // Chamada à API de CEP (ex: ViaCEP)
            if (address == null)
            {
                return BadRequest("CEP inválido.");
            }

            var nearestStation = _metroService.FindNearestMetro(address.Latitude, address.Longitude);

            return Ok(nearestStation);
        }

        private async Task<Address> GetAddressFromCep(string cep)
        {
            // Faça a chamada à API ViaCEP ou outra API de consulta de CEP
            // Exemplo de chamada simples usando HttpClient
            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var address = JsonSerializer.Deserialize<Address>(response);

            if (address != null)
            {
                address.Latitude = -23.550520;  // Exemplo de coordenadas
                address.Longitude = -46.633308;
            }

            return address;
        }
    }
}
