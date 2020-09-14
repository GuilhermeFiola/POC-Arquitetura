using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace NormasExternas.WebAPI.Interfaces.Services
{
    public interface INormaService
    {
        Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas);

        void ExcluiArquivoNorma(string localArquivoNormas);
    }
}
