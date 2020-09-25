using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.UseCases.OrgaoExpedidor;

namespace Normas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgaoExpedidorController : ControllerBase
    {
        [HttpGet("{idTipoDocumento}")]
        [Authorize]
        public async Task<IActionResult> GetOrgaoExpedidor([FromServices] BuscarOrgaoExpedidorUseCase _casoUso,
                                                          [FromRoute][Required] int idTipoDocumento)
        {
            return await _casoUso.Buscar(idTipoDocumento);
        }

        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> GetOrgaosExpedidores([FromServices] BuscarListaOrgaoExpedidorUseCase _casoUso)
        {
            return await _casoUso.Buscar();
        }
    }
}
