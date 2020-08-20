using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.SetMainEntityConfig("ESTADO");
            
            // CAMPOS DA TABELA
            builder.Property(p => p.Nome)
                .HasColumnName("NOM_ESTADO")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Sigla)
                .HasColumnName("SGL_ESTADO")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
