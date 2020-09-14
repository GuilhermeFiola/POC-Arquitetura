using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Data.Mappings
{
    public class OrgaoExpedidorMapping : IEntityTypeConfiguration<OrgaoExpedidor>
    {
        public void Configure(EntityTypeBuilder<OrgaoExpedidor> builder)
        {
            builder.ToTable("ORGAOEXPEDIDOR");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .IsRequired();

            builder
                .HasMany(f => f.Normas)
                .WithOne(f => f.OrgaoExpedidor)
                .HasForeignKey(f => f.IdOrgaoExpedidor);
        }
    }
}