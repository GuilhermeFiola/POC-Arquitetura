using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class BuscarNormaUseCase
    {

        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public BuscarNormaUseCase(IMapper mapper,
                                  INormaRepository normaRepository,
                                  ITipoDocumentoRepository tipoDocumentoRepository,
                                  IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public async Task<IActionResult> Buscar(int idNorma)
        {
            try
            {
                var norma = _normaRepository.GetById(idNorma);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

                norma.TipoDocumento = _tipoDocumentoRepository.GetById(norma.IdTipoDocumento);

                norma.OrgaoExpedicao = _orgaoExpedidorRepository.GetById(norma.IdOrgaoExpedidor);

                var normaResponse = _mapper.Map<BuscarNormaResponseDTO>(norma);

                return new OkObjectResult(normaResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
