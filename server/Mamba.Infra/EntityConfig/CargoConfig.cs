using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class CargoConfig : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.SetMainEntityConfig("CARGO");
            builder.HasOne(p => p.Empresa).WithMany(p => p.Cargos).HasForeignKey(p => p.EmpresaId);
            builder.HasOne(p => p.AreaAtuacao).WithMany(p => p.Cargos).HasForeignKey(p => p.AreaAtuacaoId);

            // CAMPOS DA TABELA
            builder.Property(p => p.EmpresaId)
                .HasColumnName("ID_EMPRESA")
                .IsRequired();

            builder.Property(p => p.AreaAtuacaoId)
                .HasColumnName("ID_AREA_ATUACAO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_CARGO")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
