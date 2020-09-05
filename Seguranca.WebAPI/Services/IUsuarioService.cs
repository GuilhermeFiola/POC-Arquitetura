using Seguranca.WebAPI.DTO;

namespace Seguranca.WebAPI.Services
{
    public interface IUsuarioService
    {
        AuthResponseDTO Autenticar(AuthRequestDTO authRequestDTO);
    }
}