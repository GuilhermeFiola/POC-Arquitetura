using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NormasExternas.WebAPI.Entities;

namespace NormasExternas.WebAPI.Data.Mappings
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

            builder.Property(p => p.TipoDocumento)
                   .IsRequired();

            builder.Property(p => p.OrgaoExpedidor)
                   .IsRequired();

            builder.Property(p => p.DataPublicacao)
                   .IsRequired();

            builder.Property(p => p.DataHoraInclusao)
                   .IsRequired();

            builder.Property(p => p.Observacao)
                   .HasMaxLength(250);

            builder.Property(p => p.Resumo)
                   .HasMaxLength(250);

            builder.Property(p => p.LocalArquivoNormas)
                   .IsRequired();
        }
    }
}