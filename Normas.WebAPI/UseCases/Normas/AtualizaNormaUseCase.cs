using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class AtualizaNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaService _normaService;
        private readonly INormaRepository _normaRepository;

        public AtualizaNormaUseCase(IMapper mapper,
                                    INormaService normaService,
                                    INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaService = normaService;
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Atualizar(AtualizarNormaRequestDTO atualizarNormaDTO)
        {
            try
            {
                var norma = _normaRepository.GetById(atualizarNormaDTO.Id);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                _normaService.ExcluiArquivoNorma(norma.LocalArquivoNormas);

                var localArquivoNormas = await _normaService.GravarArquivoNormaAsync(atualizarNormaDTO.ArquivoNorma);

                var normaUpdate = _mapper.Map<Norma>(atualizarNormaDTO);

                normaUpdate.LocalArquivoNormas = localArquivoNormas;

                _normaRepository.Update(normaUpdate);

                var normaResponse = _mapper.Map<AtualizarNormaResponseDTO>(_normaRepository.GetById(atualizarNormaDTO.Id));

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
