using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NormasExternas.WebAPI.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NormasExternas.WebAPI.Services
{
    public class NormaService : INormaService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly HttpContext _httpContext;

        public NormaService(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas)
        {
            try
            {
                var request = _httpContext.Request;
                var host = request.Host.ToUriComponent();
                var pathBase = request.PathBase.ToUriComponent();
                var nomeArquivo = Guid.NewGuid().ToString();
                var caminhoArquivo = _hostEnvironment.WebRootPath + "\\Docs\\" + nomeArquivo + ".pdf";

                if (arquivoNormas.Length > 0)
                {
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await arquivoNormas.CopyToAsync(stream);
                    }
                }

                var urlArquivo = $"{request.Scheme}://{host}{pathBase}/Docs/{nomeArquivo}.pdf";

                return urlArquivo;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar o arquivo.", ex);
            }
            
        }

        public void ExcluiArquivoNorma(string localArquivoNormas)
        {
            try
            {
                if (localArquivoNormas.Length > 0)
                {
                    File.Delete(localArquivoNormas);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao excluir o arquivo.", ex);
            }

        }
    }
}
