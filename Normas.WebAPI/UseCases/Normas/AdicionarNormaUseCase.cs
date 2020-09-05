using Normas.WebAPI.DTO.Normas;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;

namespace Normas.WebAPI.UseCases.Normas
{
    public class AdicionarNormaUseCase
    {
        private readonly INormaRepository _normaRepository;
        private readonly INormaService _normaService;
        public AdicionarNormaUseCase(INormaRepository normaRepository)
        {
            _normaRepository = normaRepository;
        }

        public AdicionarNormaResponseDTO Adicionar(AdicionarNormaRequestDTO adicionarNormaDTO)
        {

        }
    }
}
