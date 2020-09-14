using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Data.Mappings
{
    public class TipoDocumentoMapping : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("TIPODOCUMENTO");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .IsRequired();

            builder
                .HasMany(f => f.Normas)
                .WithOne(f => f.TipoDocumento)
                .HasForeignKey(f => f.IdTipoDocumento);
        }
    }
}