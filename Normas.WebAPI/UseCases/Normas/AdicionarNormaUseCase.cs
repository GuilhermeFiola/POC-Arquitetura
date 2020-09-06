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
                var localArquivoNorma = await _normaService.GravarArquivoNormaAsync(adicionarNormaDTO.ArquivoNorma);

                var tipoDocumento = _tipoDocumentoRepository.GetById(adicionarNormaDTO.TipoDocumento);

                var orgaoExpedidor = _orgaoExpedidorRepository.GetById(adicionarNormaDTO.OrgaoExpedicao);

                var norma = _mapper.Map<Norma>(adicionarNormaDTO);

                norma.TipoDocumento = tipoDocumento;
                norma.OrgaoExpedicao = orgaoExpedidor;
                norma.LocalArquivoNorma = localArquivoNorma;

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
