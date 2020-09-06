using Microsoft.EntityFrameworkCore;
using Normas.WebAPI.Data.Mappings;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Data
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
