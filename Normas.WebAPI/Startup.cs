using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using Normas.WebAPI.Repositories;
using Normas.WebAPI.Services;
using AutoMapper;
using Normas.WebAPI.Helpers;
using Normas.WebAPI.UseCases.Normas;
using Normas.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Normas.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            #region SQLite
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlite(connection)
            );
            #endregion

            #region DI Repositórios
            services.AddScoped<INormaRepository, NormaRepository>();
            services.AddScoped<IOrgaoExpedidorRepository, OrgaoExpedidorRepository>();
            services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
            #endregion

            #region DI Serviços
            services.AddScoped<INormaService, NormaService>();
            services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
            services.AddScoped<IOrgaoExpedidorService, OrgaoExpedidorService>();
            #endregion

            #region DI Use Cases
            services.AddScoped<BuscarNormaUseCase>();
            services.AddScoped<BuscarListaNormaUseCase>();
            services.AddScoped<AdicionarNormaUseCase>();
            services.AddScoped<AtualizaNormaUseCase>();
            services.AddScoped<ExcluirNormaUseCase>();
            services.AddScoped<ImportarNormaUseCase>();
            #endregion

            #region DI Mappers
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Normas API", Version = "v1" });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Normas API V1");
            });
        }
    }
}
