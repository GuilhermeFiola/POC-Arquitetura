using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Normas.WebAPI.UseCases.Normas
{
    public class BuscarNormaUseCase
    {

        private readonly IMapper _mapper;
        private readonly INormaRepository _normaRepository;

        public BuscarNormaUseCase(IMapper mapper,
                                  INormaRepository normaRepository)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
        }

        public async Task<IActionResult> Buscar(int idNorma)
        {
            try
            {
                var norma = _normaRepository.GetById(idNorma);

                if (norma == null) return new NotFoundObjectResult("Norma não localizada.");

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
