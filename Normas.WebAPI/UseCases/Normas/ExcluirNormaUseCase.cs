using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class ExcluirNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaService _normaService;
        private readonly INormaRepository _normaRepository;

        public ExcluirNormaUseCase(IMapper mapper,
                                   INormaService normaService,
                                   INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaService = normaService;
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Excluir(int idNorma)
        {
            try
            {
                var norma = _normaRepository.Delete(idNorma);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                _normaService.ExcluiArquivoNorma(norma.LocalArquivoNormas);

                var normaResponse = _mapper.Map<ExcluirNormaResponseDTO>(norma);

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
