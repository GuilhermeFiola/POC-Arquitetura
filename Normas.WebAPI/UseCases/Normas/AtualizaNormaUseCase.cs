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
                var localArquivoNormas = string.Empty;
                var norma = _normaRepository.GetById(atualizarNormaDTO.Id);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                var normaUpdate = _mapper.Map<Norma>(atualizarNormaDTO);
                normaUpdate.Externa = norma.Externa;

                if (norma.Externa == "N" && normaUpdate.LocalArquivoNormas != null)
                {
                    _normaService.ExcluiArquivoNorma(norma.LocalArquivoNormas);
                    localArquivoNormas = await _normaService.GravarArquivoNormaAsync(atualizarNormaDTO.ArquivoNorma);
                    normaUpdate.LocalArquivoNormas = localArquivoNormas;
                } else
                {
                    normaUpdate.LocalArquivoNormas = norma.LocalArquivoNormas;
                }
                
                if(norma.Externa == "S")
                {
                    normaUpdate.CodigoNorma = norma.CodigoNorma;
                    normaUpdate.DataPublicacao = norma.DataPublicacao;
                }

                _normaRepository.Update(normaUpdate);

                var normaResponse = _mapper.Map<AtualizarNormaResponseDTO>(_normaRepository.GetById(atualizarNormaDTO.Id));

                if (norma.Externa == "N")
                {
                    normaResponse.LocalArquivoNormas = _normaService.RetornaLinkArquivoNorma(normaResponse.LocalArquivoNormas);
                }

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
