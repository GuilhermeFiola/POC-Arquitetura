using Microsoft.AspNetCore.Mvc;
using Seguranca.WebAPI.DTO;
using Seguranca.WebAPI.Services;

namespace Seguranca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("autenticar")]
        public IActionResult Autenticar(AuthRequestDTO authRequestDTO)
        {
            var response = _usuarioService.Autenticar(authRequestDTO);

            if (response == null) return Unauthorized(new { message = "Usuário ou senha incorretos." });

            return Ok(response);
        }
    }
}
