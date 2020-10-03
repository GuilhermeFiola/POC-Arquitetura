using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.UseCases.Normas;

namespace Normas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        [HttpGet("{idNorma}")]
        [Authorize]
        public async Task<IActionResult> GetNorma([FromServices] BuscarNormaUseCase _casoUso,
                                                  [FromRoute][Required] int idNorma)
        {
            return await _casoUso.Buscar(idNorma);
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetNormas([FromServices] BuscarListaNormaUseCase _casoUso,
                                                   [FromQuery] BuscarNormaRequestQuery filtrosNormas)
        {
            return await _casoUso.Buscar(filtrosNormas);
        }

        [HttpPost()]
        [Authorize(Roles = "Analista")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> PostNorma([FromServices]AdicionarNormaUseCase _casoUso,
                                                   [FromForm][Required] AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            return await _casoUso.Adicionar(adicionarNormaDTO);
        }

        [HttpPut()]
        [Authorize(Roles = "Analista")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> PutNorma([FromServices] AtualizaNormaUseCase _casoUso,
                                                  [FromForm][Required] AtualizarNormaRequestDTO atualizarNormaDTO)
        {
            return await _casoUso.Atualizar(atualizarNormaDTO);
        }

        [HttpDelete("{idNorma}")]
        [Authorize(Roles = "Analista")]
        public async Task<IActionResult> DeleteNorma([FromServices] ExcluirNormaUseCase _casoUso,
                                                     [FromRoute][Required] int idNorma)
        {
            return await _casoUso.Excluir(idNorma);
        }

        [HttpGet("{idNorma}/arquivo")]
        public async Task<IActionResult> GetArquivoNorma([FromServices] BuscarArquivoUseCase _casoUso,
                                                         [FromRoute][Required] int idNorma)
        {
            return await _casoUso.Buscar(idNorma);
        }

        [HttpPost("importar")]
        [AllowAnonymous]
        public async Task<IActionResult> PostImportar([FromServices] ImportarNormaUseCase _casoUso,
                                                      [FromBody][Required] ImportarNormaRequestDTO importarNormaDTO)
        {
            return await _casoUso.Importar(importarNormaDTO);
        }

    }
}
