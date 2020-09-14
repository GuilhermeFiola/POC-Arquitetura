using Microsoft.EntityFrameworkCore;
using Normas.WebAPI.Data.Mappings;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Norma> Normas { get; set; }
        public DbSet<OrgaoExpedidor> OrgaosExpedidores { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NormaMapping());
            builder.ApplyConfiguration(new TipoDocumentoMapping());
            builder.ApplyConfiguration(new OrgaoExpedidorMapping());

            builder.Entity<TipoDocumento>().HasData(
                new TipoDocumento() { Id = 1, Descricao = "Indefinido" },
                new TipoDocumento() { Id = 2, Descricao = "Norma de Base" },
                new TipoDocumento() { Id = 3, Descricao = "Norma de Terminologia" },
                new TipoDocumento() { Id = 4, Descricao = "Norma de Ensaio" },
                new TipoDocumento() { Id = 5, Descricao = "Norma de Produto" },
                new TipoDocumento() { Id = 6, Descricao = "Norma de Processo" },
                new TipoDocumento() { Id = 7, Descricao = "Norma de Serviço" }
            );

            builder.Entity<OrgaoExpedidor>().HasData(
                new OrgaoExpedidor() { Id = 1, Descricao = "Indefinido" },
                new OrgaoExpedidor() { Id = 2, Descricao = "ABNT" },
                new OrgaoExpedidor() { Id = 3, Descricao = "ISO" }
            );

            base.OnModelCreating(builder);
        }
    }
}
