using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class RespostaConfig : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.SetMainEntityConfig("RESPOSTA");
            builder.HasOne(p => p.Inscricao).WithMany(p => p.Respostas).HasForeignKey(p => p.InscricaoId);
            builder.HasOne(p => p.Questao).WithMany(p => p.Respostas).HasForeignKey(p => p.QuestaoId);

            // CAMPOS DA TABELA
            builder.Property(p => p.InscricaoId)
                .HasColumnName("ID_INSCRICAO")
                .IsRequired();

            builder.Property(p => p.QuestaoId)
                .HasColumnName("ID_QUESTAO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_RESPOSTA")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
