using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class AtualizaNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaService _normaService;
        private readonly INormaRepository _normaRepository;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public AtualizaNormaUseCase(IMapper mapper,
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

        public async Task<IActionResult> Atualizar(AtualizarNormaRequestDTO atualizarNormaDTO)
        {
            try
            {
                var norma = _normaRepository.GetById(atualizarNormaDTO.Id);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                _normaService.ExcluiArquivoNorma(norma.LocalArquivoNorma);

                var localArquivoNorma = await _normaService.GravarArquivoNormaAsync(atualizarNormaDTO.ArquivoNorma);

                var normaUpdate = _mapper.Map<Norma>(atualizarNormaDTO);

                normaUpdate.TipoDocumento = _tipoDocumentoRepository.GetById(normaUpdate.IdTipoDocumento);
                normaUpdate.OrgaoExpedicao = _orgaoExpedidorRepository.GetById(normaUpdate.IdOrgaoExpedidor);
                normaUpdate.LocalArquivoNorma = localArquivoNorma;

                var normaResponse = _mapper.Map<AtualizarNormaResponseDTO>(_normaRepository.Update(normaUpdate));

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
