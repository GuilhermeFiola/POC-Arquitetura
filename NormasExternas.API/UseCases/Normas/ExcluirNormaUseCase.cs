using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NormasExternas.WebAPI.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace NormasExternas.WebAPI.UseCases.Normas
{
    public class ExcluirNormaUseCase
    {
        private readonly INormaRepository _normaRepository;

        public ExcluirNormaUseCase(IMapper mapper,
                                   INormaRepository normaRepository)
        {
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Excluir(int idNorma)
        {
            try
            {
                var normaResponse = _normaRepository.Delete(idNorma);

                return new OkObjectResult(normaResponse);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
