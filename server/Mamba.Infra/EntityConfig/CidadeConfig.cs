using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.SetMainEntityConfig("CIDADE");
            builder.HasOne(p => p.Estado).WithMany(p => p.Cidades).HasForeignKey(p => p.EstadoId);

            // CAMPOS DA TABELA
            builder.Property(p => p.EstadoId)
                .HasColumnName("ID_ESTADO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_CIDADE")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("SGL_CIDADE")
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
