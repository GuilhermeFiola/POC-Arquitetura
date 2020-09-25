using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.TipoDocumento;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.TipoDocumento
{
    public class BuscarTipoDocumentoUseCase
    {

        private readonly IMapper _mapper;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        public BuscarTipoDocumentoUseCase(IMapper mapper,
                                          ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _mapper = mapper;
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public async Task<IActionResult> Buscar(int idOrgaoExpedidor)
        {
            try
            {
                var tipoDocumento = _tipoDocumentoRepository.GetById(idOrgaoExpedidor);

                if (tipoDocumento == null) return new NotFoundObjectResult("Orgão expedidor não localizado.");

                var tipoDocumentoResponse = _mapper.Map<BuscarTipoDocumentoResponseDTO>(tipoDocumento);

                return new OkObjectResult(tipoDocumentoResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
