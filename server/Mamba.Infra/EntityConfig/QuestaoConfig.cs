using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class QuestaoConfig : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.SetMainEntityConfig("QUESTAO");
            builder.HasOne(p => p.Desafio).WithMany(p => p.Questoes).HasForeignKey(p => p.DesafioId);

            // CAMPOS DA TABELA
            builder.Property(p => p.DesafioId)
                .HasColumnName("ID_DESAFIO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_QUESTAO")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
