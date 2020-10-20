using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class DesafioConfig : IEntityTypeConfiguration<Desafio>
    {
        public void Configure(EntityTypeBuilder<Desafio> builder)
        {
            builder.SetMainEntityConfig("DESAFIO");
            builder.HasOne(p => p.Empresa).WithMany(p => p.Desafios).HasForeignKey(p => p.EmpresaId);
            builder.HasOne(p => p.Cargo).WithMany(p => p.Desafios).HasForeignKey(p => p.CargoId);

            // CAMPOS DA TABELA
            builder.Property(p => p.EmpresaId)
                .HasColumnName("ID_EMPRESA")
                .IsRequired();

            builder.Property(p => p.CargoId)
                .HasColumnName("ID_CARGO");

            builder.Property(p => p.LimiteInscricao)
                .HasColumnName("QTD_LIMITE_INSCRICAO");

            builder.Property(p => p.DataAbertura)
                .HasColumnName("DAT_ABERTURA")
                .IsRequired();

            builder.Property(p => p.DataFechamento)
                .HasColumnName("DAT_FECHAMENTO");
        }
    }
}
