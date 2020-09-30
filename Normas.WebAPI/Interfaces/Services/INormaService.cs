using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Normas.WebAPI.Interfaces.Services
{
    public interface INormaService
    {
        Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas);

        void ExcluiArquivoNorma(string localArquivoNormas);

        string RetornaLinkArquivoNorma(string localArquivoInterno);

        Stream RetornaStreamArquivo(string localArquivoInterno);
    }
}
