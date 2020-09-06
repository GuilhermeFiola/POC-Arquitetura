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

        public NormaService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas)
        {
            try
            {
                var caminhoArquivo = this._hostEnvironment.WebRootPath + "\\Docs\\" + Guid.NewGuid() + ".pdf";

                if (arquivoNormas.Length > 0)
                {
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await arquivoNormas.CopyToAsync(stream);
                    }
                }

                return caminhoArquivo;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao salvar o arquivo.", ex);
            }
            
        }

        public void ExcluiArquivoNormaAsync(string localArquivoNormas)
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
