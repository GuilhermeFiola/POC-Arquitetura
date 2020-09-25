using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class BuscarNormaUseCase
    {

        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;
        private readonly INormaService _normaService;

        public BuscarNormaUseCase(IMapper mapper,
                                  INormaRepository normaRepository,
                                  INormaService normaService)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
            _normaService = normaService;
        }

        public async Task<IActionResult> Buscar(int idNorma)
        {
            try
            {
                var norma = _normaRepository.GetById(idNorma);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                var normaResponse = _mapper.Map<BuscarNormaResponseDTO>(norma);

                normaResponse.LocalArquivoNormas = normaResponse.Externa == "N" ?
                        _normaService.RetornaLinkArquivoNorma(normaResponse.LocalArquivoNormas) : normaResponse.LocalArquivoNormas;

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
