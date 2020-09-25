using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.TipoDocumento;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.TipoDocumento
{
    public class BuscarListaTipoDocumentoUseCase
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public BuscarListaTipoDocumentoUseCase(IMapper mapper,
                                               ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _mapper = mapper;
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public async Task<IActionResult> Buscar()
        {
            try
            {
                var listaTipoDocumentos = _tipoDocumentoRepository.GetAll();

                if (!listaTipoDocumentos.Any()) return new NotFoundObjectResult("Orgãos expedidores não localizados.");

                var listaTipoDocumentosResponse = _mapper.Map<IEnumerable<BuscarTipoDocumentoResponseDTO>>(listaTipoDocumentos);

                return new OkObjectResult(listaTipoDocumentosResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
