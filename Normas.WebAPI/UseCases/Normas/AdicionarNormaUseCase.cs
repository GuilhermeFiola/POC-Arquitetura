using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class AdicionarNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaService _normaService;
        private readonly INormaRepository _normaRepository;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public AdicionarNormaUseCase(IMapper mapper,
                                     INormaService normaService,
                                     INormaRepository normaRepository,
                                     ITipoDocumentoRepository tipoDocumentoRepository,
                                     IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _mapper = mapper;
            _normaService = normaService;
            _normaRepository = normaRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public async Task<IActionResult> Adicionar(AdicionarNormaRequestDTO adicionarNormaDTO)
        {
            try
            {
                var localArquivoNormas = await _normaService.GravarArquivoNormaAsync(adicionarNormaDTO.ArquivoNorma);
                
                var norma = _mapper.Map<Norma>(adicionarNormaDTO);

                norma.TipoDocumento = _tipoDocumentoRepository.GetById(norma.IdTipoDocumento);
                norma.OrgaoExpedidor = _orgaoExpedidorRepository.GetById(norma.IdOrgaoExpedidor);
                norma.LocalArquivoNormas = localArquivoNormas;

                var normaResponse = _mapper.Map<AdicionarNormaResponseDTO>(_normaRepository.Insert(norma));

                normaResponse.LocalArquivoNormas = _normaService.RetornaLinkArquivoNorma(localArquivoNormas);

                return new OkObjectResult(normaResponse);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
