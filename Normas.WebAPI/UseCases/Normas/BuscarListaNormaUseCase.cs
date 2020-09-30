using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
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
        private readonly INormaService _normaService;

        public BuscarListaNormaUseCase(IMapper mapper,
                                       INormaRepository normaRepository,
                                       INormaService normaService)
        {
            _mapper = mapper;
            _normaRepository = normaRepository;
            _normaService = normaService;
        }

        public async Task<IActionResult> Buscar(BuscarNormaRequestQuery filtrosNormas)
        {
            try
            {
                var listaNormas = _normaRepository.GetAll();

                if(filtrosNormas.CodigoNorma != null)
                {
                    listaNormas = listaNormas.Where(w => w.CodigoNorma == filtrosNormas.CodigoNorma);
                }

                if (filtrosNormas.Descricao != null)
                {
                    listaNormas = listaNormas.Where(w => w.Descricao.Contains(filtrosNormas.Descricao));
                }

                if (filtrosNormas.DataPublicacao != null)
                {
                    listaNormas = listaNormas.Where(w => w.DataPublicacao == filtrosNormas.DataPublicacao);
                }

                if (filtrosNormas.TipoDocumento != null)
                {
                    listaNormas = listaNormas.Where(w => w.TipoDocumento.Id == filtrosNormas.TipoDocumento);
                }

                if (filtrosNormas.OrgaoExpedidor != null)
                {
                    listaNormas = listaNormas.Where(w => w.OrgaoExpedidor.Id == filtrosNormas.OrgaoExpedidor);
                }

                if (!listaNormas.Any()) return new NotFoundObjectResult("Normas não localizadas.");

                var listaNormasResponse = _mapper.Map<IEnumerable<BuscarNormaResponseDTO>>(listaNormas);

                foreach(var norma in listaNormasResponse)
                {
                    norma.LocalArquivoNormas = norma.Externa == "N" ? 
                        _normaService.RetornaLinkArquivoNorma(norma.LocalArquivoNormas) : norma.LocalArquivoNormas;
                }

                return new OkObjectResult(listaNormasResponse);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
