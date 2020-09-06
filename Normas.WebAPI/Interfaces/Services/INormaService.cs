using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Normas.WebAPI.Interfaces.Services
{
    public interface INormaService
    {
        Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas);

        void ExcluiArquivoNormaAsync(string localArquivoNormas);
    }
}
