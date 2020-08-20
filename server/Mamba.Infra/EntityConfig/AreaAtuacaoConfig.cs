using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class AreaAtuacaoConfig : IEntityTypeConfiguration<AreaAtuacao>
    {
        public void Configure(EntityTypeBuilder<AreaAtuacao> builder)
        {
            builder.SetMainEntityConfig("AREA_ATUACAO");

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_AREA_ATUACAO")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
