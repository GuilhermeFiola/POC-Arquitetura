using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitoramento.DTO.Normas;
using Monitoramento.Worker.DTO.Normas;
using Monitoramento.Worker.Interfaces;
using Newtonsoft.Json;

namespace Monitoramento.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private readonly IEmailSender _emailSender;

        public Worker(ILogger<Worker> logger,
                      IConfiguration configuration,
                      IEmailSender emailSender)
        {
            _configuration = configuration;
            _logger = logger;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var listaEmails = new List<string>();
            var urlBaseNormasExterna = _configuration.GetSection("urlBaseNormasExterna").Value;
            var urlModuloNormas = _configuration.GetSection("urlModuloNormas").Value;
            var intervaloExecucao = int.Parse(_configuration.GetSection("intervalo").Value);

            listaEmails.Add(_configuration.GetSection("EmailNotificacao").Value);

            
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Iniciando processo de monitoramento de normas em: {time}", DateTimeOffset.Now);

                    using (var clientExterno = new HttpClient())
                    {
                        _logger.LogInformation("Obtendo normas do serviço externo em: {time}", DateTimeOffset.Now);

                        clientExterno.BaseAddress = new Uri(urlBaseNormasExterna);
                        clientExterno.DefaultRequestHeaders.Accept.Clear();
                        clientExterno.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage responseNormasExternas = clientExterno.GetAsync("/api/normasexternas").Result;

                        if (responseNormasExternas.StatusCode == HttpStatusCode.OK)
                        {
                            string responseBody = await responseNormasExternas.Content.ReadAsStringAsync();
                            var listaNormasExternas = JsonConvert.DeserializeObject<List<NormasExternasDTO>>(responseBody);

                            _logger.LogInformation("Inserindo normas da base externa no módulo de normas: {time}", DateTimeOffset.Now);

                            using (var clientNormas = new HttpClient())
                            {

                                clientNormas.BaseAddress = new Uri(urlModuloNormas);
                                clientNormas.DefaultRequestHeaders.Accept.Clear();
                                clientNormas.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                                foreach (var norma in listaNormasExternas)
                                {
                                    HttpResponseMessage responseNormas = clientNormas.PostAsync("/normas/importar", new StringContent(JsonConvert.SerializeObject(norma), Encoding.UTF8, "application/json")).Result;

                                    if (responseNormas.StatusCode == HttpStatusCode.OK)
                                    {
                                        responseBody = await responseNormasExternas.Content.ReadAsStringAsync();
                                        var respostaImportacaoNorma = JsonConvert.DeserializeObject<List<NormaImportadaDTO>>(responseBody).FirstOrDefault();

                                        _logger.LogInformation("Norma {CodigoNorma} da base externa inserida no módulo de normas: {time}", respostaImportacaoNorma.CodigoNorma, DateTimeOffset.Now);

                                        var mensagemEmail =
                                            string.Format("Realizada a importação da norma com o código {0}\n" +
                                            ", descrição: {1}\n" +
                                            ", data de publicação: {2}\n" +
                                            "e local arquivo: {3}",
                                            respostaImportacaoNorma.CodigoNorma, respostaImportacaoNorma.Descricao,
                                            respostaImportacaoNorma.DataPublicacao, respostaImportacaoNorma.LocalArquivoNormas);

                                        await _emailSender.SendEmailAsync(listaEmails, $"Importação da norma {respostaImportacaoNorma.CodigoNorma}", mensagemEmail);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocorreu um erro no processo de importação de normas em: {time}", DateTimeOffset.Now);
                }

                _logger.LogInformation("Concluindo verificacao de normas em: {time}", DateTimeOffset.Now);
                await Task.Delay(intervaloExecucao, stoppingToken);
            } 
        }
    }
}
