using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class BuscarArquivoUseCase : ControllerBase
    {
        private readonly INormaRepository _normaRepository;
        private readonly INormaService _normaService;

        public BuscarArquivoUseCase(INormaRepository normaRepository,
                                    INormaService normaService)
        {
            _normaRepository = normaRepository;
            _normaService = normaService;
        }

        public async Task<IActionResult> Buscar(int idNorma)
        {
            try
            {
                var norma = _normaRepository.GetById(idNorma);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                var arquivoNorma = _normaService.RetornaStreamArquivo(norma.LocalArquivoNormas);

                if(arquivoNorma == null)
                {
                    return new NotFoundObjectResult("Arquivo de normas não localizado");
                }

                return File(arquivoNorma, "application/octet-stream");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
