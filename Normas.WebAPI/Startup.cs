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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Normas.WebAPI.UseCases.OrgaoExpedidor;
using Normas.WebAPI.UseCases.TipoDocumento;

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
            services.AddControllers()
                    .AddNewtonsoftJson(o => {
                        o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    })
                    .AddJsonOptions(options => {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("Cors", builder =>
                                    builder.AllowAnyOrigin()
                                           .AllowAnyMethod()
                                           .AllowAnyHeader());
            });

            #region Autenticação e Autorização
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region SQLite
            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlite(connection)
            );
            #endregion

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
            services.AddScoped<BuscarArquivoUseCase>(); 

            services.AddScoped<BuscarOrgaoExpedidorUseCase>();
            services.AddScoped<BuscarListaOrgaoExpedidorUseCase>();

            services.AddScoped<BuscarTipoDocumentoUseCase>();
            services.AddScoped<BuscarListaTipoDocumentoUseCase>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("Cors");

            app.UseFileServer();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Normas API V1");
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
