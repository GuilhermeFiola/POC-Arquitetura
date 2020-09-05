using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;

namespace Normas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        private readonly INormasService _normasService;

        public NormasController(IUsuarioService normasService)
        {
            _normasService = normasService;
        }

        [HttpGet("{idNorma}")]
        public IActionResult GetNorma(int idNorma)
        {
            var response = _normasService.Autenticar(authRequestDTO);

            if (response == null) return Unauthorized(new { message = "Usuário ou senha incorretos." });

            return Ok(response);
        }

        [HttpPost()]
        public IActionResult PostNorma(AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            var response = _normasService.Autenticar(authRequestDTO);

            if (response == null) return Unauthorized(new { message = "Usuário ou senha incorretos." });

            return Ok(response);
        }

    }
}
