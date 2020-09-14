using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NormasExternas.WebAPI.DTO.Normas;
using NormasExternas.WebAPI.Entities;
using NormasExternas.WebAPI.Interfaces.Repositories;
using NormasExternas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NormasExternas.WebAPI.UseCases.Normas
{
    public class AdicionarNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaService _normaService;
        private readonly INormaRepository _normaRepository;

        public AdicionarNormaUseCase(IMapper mapper,
                                     INormaService normaService,
                                     INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaService = normaService;
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Adicionar(AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            try
            {
                var localArquivoNormas = await _normaService.GravarArquivoNormaAsync(adicionarNormaDTO.ArquivoNorma);

                var norma = _mapper.Map<Norma>(adicionarNormaDTO);

                norma.LocalArquivoNormas = localArquivoNormas;

                var normaResponse = _mapper.Map<AdicionarNormaResponseDTO>(_normaRepository.Insert(norma));

                return new OkObjectResult(normaResponse);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
