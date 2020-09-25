using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.OrgaoExpedidor;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.OrgaoExpedidor
{
    public class BuscarOrgaoExpedidorUseCase
    {

        private readonly IMapper _mapper;
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;

        public BuscarOrgaoExpedidorUseCase(IMapper mapper,
                                           IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _mapper = mapper;
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public async Task<IActionResult> Buscar(int idOrgaoExpedidor)
        {
            try
            {
                var orgaoExpedidor = _orgaoExpedidorRepository.GetById(idOrgaoExpedidor);

                if (orgaoExpedidor == null) return new NotFoundObjectResult("Orgão expedidor não localizado.");

                var orgaoExpedidorResponse = _mapper.Map<BuscarOrgaoExpedidorResponseDTO>(orgaoExpedidor);

                return new OkObjectResult(orgaoExpedidorResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
