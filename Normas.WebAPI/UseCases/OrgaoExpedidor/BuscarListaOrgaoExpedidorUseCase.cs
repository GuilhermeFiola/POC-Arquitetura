using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.OrgaoExpedidor;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.OrgaoExpedidor
{
    public class BuscarListaOrgaoExpedidorUseCase
    {

        private readonly IMapper _mapper;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public BuscarListaOrgaoExpedidorUseCase(IMapper mapper,
                                                IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _mapper = mapper;
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public async Task<IActionResult> Buscar()
        {
            try
            {
                var listaOrgaosExpedidores = _orgaoExpedidorRepository.GetAll();

                if (!listaOrgaosExpedidores.Any()) return new NotFoundObjectResult("Orgãos expedidores não localizados.");

                var listaOrgaosExpedidoresResponse = _mapper.Map<IEnumerable<BuscarOrgaoExpedidorResponseDTO>>(listaOrgaosExpedidores);

                return new OkObjectResult(listaOrgaosExpedidoresResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
