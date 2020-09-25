using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Data.Mappings
{
    public class NormaMapping : IEntityTypeConfiguration<Norma>
    {
        public void Configure(EntityTypeBuilder<Norma> builder)
        {
            builder.ToTable("NORMA");

            builder.HasKey(k => k.Id);

            builder.HasIndex(u => u.CodigoNorma).IsUnique();

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(p => p.CodigoNorma)
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.IdTipoDocumento)
                   .IsRequired();

            builder.Property(p => p.IdOrgaoExpedidor)
                   .IsRequired();

            builder.Property(p => p.DataPublicacao)
                   .IsRequired();

            builder.Property(p => p.Observacao)
                   .HasMaxLength(250);

            builder.Property(p => p.Resumo)
                   .HasMaxLength(250);

            builder.Property(p => p.Externa)
                   .IsRequired();

            builder.Property(p => p.LocalArquivoNormas)
                   .IsRequired();

        builder.HasOne(f => f.TipoDocumento)
                   .WithMany(f => f.Normas)
                   .HasForeignKey(f => f.IdTipoDocumento);

            builder.HasOne(f => f.OrgaoExpedidor)
                   .WithMany(f => f.Normas)
                   .HasForeignKey(f => f.IdOrgaoExpedidor);
        }
    }
}