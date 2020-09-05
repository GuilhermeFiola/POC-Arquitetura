using Microsoft.AspNetCore.Http;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Normas.WebAPI.Services
{
    public class NormaService : INormaService
    {
        public async Task<string> GravarArquivoNormaAsync(IFormFile arquivoNormas)
        {
            try
            {
                var caminhoArquivo = Path.GetTempFileName();

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
    }
}
