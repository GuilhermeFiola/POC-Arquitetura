using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class ImportarNormaUseCase
    {
        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly IOrgaoExpedidorService _orgaoExpedidorService;

        public ImportarNormaUseCase(IMapper mapper,
                                    INormaRepository normaRepository,
                                    ITipoDocumentoService tipoDocumentoService,
                                    IOrgaoExpedidorService orgaoExpedidorService)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
            _tipoDocumentoService = tipoDocumentoService;
            _orgaoExpedidorService = orgaoExpedidorService;
        }

        public async Task<IActionResult> Importar(ImportarNormaRequestDTO importarNormaDTO)
        {
            try
            {
                var normaExistente = _normaRepository.GetAll().FirstOrDefault(w => w.CodigoNorma == importarNormaDTO.CodigoNorma);

                var normaImportacao = _mapper.Map<Norma>(importarNormaDTO);

                normaImportacao.TipoDocumento = _tipoDocumentoService.BuscarTipoDocumentoPorDescricao(importarNormaDTO.TipoDocumento);
                normaImportacao.OrgaoExpedicao = _orgaoExpedidorService.BuscarOrgaoExpedidorPorDescricao(importarNormaDTO.OrgaoExpedicao);

                if (normaExistente != null)
                {
                    normaImportacao.Id = normaExistente.Id;
                    normaImportacao = _normaRepository.Update(normaImportacao);
                } 
                else
                {
                    normaImportacao = _normaRepository.Insert(normaImportacao);
                }

                var normaResponse = _mapper.Map<ImportarNormaResponseDTO>(normaImportacao);

                return new OkObjectResult(normaResponse);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
