using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.UseCases.Normas;

namespace Normas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormasController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetNorma([FromServices] AdicionarNormaUseCase _casoUso,
        //                                          [FromRoute] int idNorma)
        //{
        //    return await _casoUso.Adicionar(adicionarNormaDTO);
        //}

        //[HttpGet()]
        //public async Task<IActionResult> GetNormas([FromServices] AdicionarNormaUseCase _casoUso)
        //{
        //    return await _casoUso.Adicionar(adicionarNormaDTO);
        //}


        [HttpPost()]
        public async Task<IActionResult> PostNorma([FromServices]AdicionarNormaUseCase _casoUso,
                                                   [FromForm] AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            return await _casoUso.Adicionar(adicionarNormaDTO);
        }

        //[HttpPut()]
        //public async Task<IActionResult> PutNorma([FromServices] AdicionarNormaUseCase _casoUso,
        //                                          [FromForm] AdicionarNormaRequestDTO adicionarNormaDTO)
        //{
        //    return await _casoUso.Adicionar(adicionarNormaDTO);
        //}

        [HttpDelete("{idNorma}")]
        public async Task<IActionResult> DeleteNorma([FromServices] ExcluirNormaUseCase _casoUso,
                                                     [FromRoute] int idNorma)
        {
            return await _casoUso.Excluir(idNorma);
        }

    }
}
