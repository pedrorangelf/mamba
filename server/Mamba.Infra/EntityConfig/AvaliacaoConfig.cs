using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class AvaliacaoConfig : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.SetMainEntityConfig("AVALIACAO");
            builder.HasOne(p => p.Funcionario).WithMany(p => p.Avaliacoes).HasForeignKey(p => p.FuncionarioId);
            builder.HasOne(p => p.Resposta).WithOne(p => p.Avaliacao).HasForeignKey<Avaliacao>(p => p.RespostaId);

            builder.Property(p => p.FuncionarioId)
                .HasColumnName("ID_FUNCIONARIO")
                .IsRequired();

            builder.Property(p => p.RespostaId)
                .HasColumnName("ID_RESPOSTA")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_AVALIACAO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Aprovado)
                .HasColumnName("IND_APROVADO")
                .IsRequired();

            builder.Property(p => p.Nota)
                .HasColumnName("NUM_NOTA")
                .IsRequired();
        }
    }
}
