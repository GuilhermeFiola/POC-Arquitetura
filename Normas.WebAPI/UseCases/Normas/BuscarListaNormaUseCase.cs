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
    public class BuscarListaNormaUseCase
    {

        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public BuscarListaNormaUseCase(IMapper mapper,
                                  INormaRepository normaRepository,
                                  ITipoDocumentoRepository tipoDocumentoRepository,
                                  IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public async Task<IActionResult> Buscar()
        {
            try
            {
                var listaNormas = _normaRepository.GetAll();

                if (!listaNormas.Any()) return new NotFoundObjectResult("Normas não localizadas.");

                foreach(var norma in listaNormas)
                {
                    norma.TipoDocumento = _tipoDocumentoRepository.GetById(norma.IdTipoDocumento);
                    norma.OrgaoExpedicao = _orgaoExpedidorRepository.GetById(norma.IdOrgaoExpedidor);
                }

                var listaNormasResponse = _mapper.Map<IEnumerable<BuscarNormaResponseDTO>>(listaNormas);

                return new OkObjectResult(listaNormasResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
