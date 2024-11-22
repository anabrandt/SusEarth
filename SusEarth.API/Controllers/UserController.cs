using Microsoft.AspNetCore.Mvc;
using SusEarth.API.Services;
using SusEarth.API.Models;

namespace SusEarth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retorna um usuário com base no ID fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de Solicitação:
        /// 
        ///     GET api/user/1
        /// 
        /// Retorna os detalhes de um usuário com ID 1.
        /// </remarks>
        /// <param name="id">O ID do usuário a ser recuperado</param>
        /// <response code="200">Retorna os detalhes do usuário</response>
        /// <response code="404">Usuário não encontrado com o ID fornecido</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário com os dados fornecidos.
        /// </summary>
        /// <remarks>
        /// Exemplo de Solicitação:
        /// 
        ///     POST api/user
        ///     {
        ///         "name": "João Silva",
        ///         "email": "joao.silva@example.com",
        ///         "cpf": "123.456.789-00"
        ///     }
        /// 
        /// Cria um usuário com as informações fornecidas e retorna o usuário recém-criado.
        /// </remarks>
        /// <param name="user">Informações do usuário a ser criado</param>
        /// <response code="201">Usuário criado com sucesso</response>
        /// <response code="400">Informações do usuário inválidas ou ausentes</response>
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }
    }
}
