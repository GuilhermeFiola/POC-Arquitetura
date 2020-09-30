using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NormasExternas.WebAPI.Data;
using NormasExternas.WebAPI.Helpers;
using NormasExternas.WebAPI.Interfaces.Repositories;
using NormasExternas.WebAPI.Repositories;
using NormasExternas.WebAPI.UseCases.Normas;
using System.Linq;

namespace NormasExternas.API
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

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region SQLite
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlite(connection)
            );
            #endregion

            #region DI Repositórios
            services.AddScoped<INormaRepository, NormaRepository>();
            #endregion

            #region DI Use Cases
            services.AddScoped<BuscarListaNormaUseCase>();
            services.AddScoped<AdicionarNormaUseCase>();
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Normas Externas API", Version = "v1" });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseFileServer();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Normas Externas API V1");
            });

            // Criação do banco de dados
            if (env.IsProduction())
            {
                using var scope = app.ApplicationServices.CreateScope();
                using var context = scope.ServiceProvider.GetService<ApiContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
