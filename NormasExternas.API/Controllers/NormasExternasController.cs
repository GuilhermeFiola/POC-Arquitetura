using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormasExternas.WebAPI.DTO.Normas;
using NormasExternas.WebAPI.UseCases.Normas;

namespace NormasExternas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasExternasController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> GetNormas([FromServices] BuscarListaNormaUseCase _casoUso)
        {
            return await _casoUso.Buscar();
        }

        [HttpPost()]
        public async Task<IActionResult> PostNorma([FromServices]AdicionarNormaUseCase _casoUso,
                                                   [FromBody] AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            return await _casoUso.Adicionar(adicionarNormaDTO);
        }
    }
}
