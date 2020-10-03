using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitoramento.Worker.Interfaces;
using Monitoramento.Worker.Services;

namespace Monitoramento.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IEmailSender, EmailSender>();
                    services.AddHostedService<Worker>();
                });
    }
}
