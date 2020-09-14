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

        public BuscarListaNormaUseCase(IMapper mapper,
                                  INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Buscar()
        {
            try
            {
                var listaNormas = _normaRepository.GetAll();

                if (!listaNormas.Any()) return new NotFoundObjectResult("Normas não localizadas.");

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
