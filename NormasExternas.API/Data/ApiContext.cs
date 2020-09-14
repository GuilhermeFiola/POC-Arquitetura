using Microsoft.EntityFrameworkCore;
using NormasExternas.WebAPI.Data.Mappings;
using NormasExternas.WebAPI.Entities;

namespace NormasExternas.WebAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Norma> Normas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NormaMapping());
            base.OnModelCreating(builder);
        }
    }
}
