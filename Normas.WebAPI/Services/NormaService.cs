using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Normas.WebAPI.Services
{
    public class NormaService : INormaService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly HttpContext _httpContext;

        public NormaService(IWebHostEnvironment hostEnvironment,
                            IHttpContextAccessor httpContextAccessor)
        {
            _hostEnvironment = hostEnvironment;
            _httpContext = httpContextAccessor.HttpContext;
        }


        public async Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas)
        {
            try
            {
                var nomeArquivo = Guid.NewGuid().ToString();
                var localArquivoInterno = "\\Docs\\" + nomeArquivo + ".pdf";
                var caminhoArquivo = _hostEnvironment.WebRootPath + localArquivoInterno;

                if (arquivoNormas.Length > 0)
                {
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await arquivoNormas.CopyToAsync(stream);
                    }
                }

                return localArquivoInterno;
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
                var caminhoArquivo = _hostEnvironment.WebRootPath + localArquivoNormas;

                if (localArquivoNormas.Length > 0)
                {
                    File.Delete(caminhoArquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao excluir o arquivo.", ex);
            }

        }

        public string RetornaLinkArquivoNorma(string localArquivoInterno)
        {
            var request = _httpContext.Request;
            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}{localArquivoInterno.Replace("\\", "/")}";
        }
    }
}
