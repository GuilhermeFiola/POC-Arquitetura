using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.UseCases.TipoDocumento;

namespace Normas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        [HttpGet("{idTipoDocumento}")]
        [Authorize]
        public async Task<IActionResult> GetTipoDocumento([FromServices] BuscarTipoDocumentoUseCase _casoUso,
                                                          [FromRoute][Required] int idTipoDocumento)
        {
            return await _casoUso.Buscar(idTipoDocumento);
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetTipoDocumentos([FromServices] BuscarListaTipoDocumentoUseCase _casoUso)
        {
            return await _casoUso.Buscar();
        }
    }
}
