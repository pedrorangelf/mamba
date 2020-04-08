using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class QuestaoConfig : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("QUESTAO");
            builder.HasKey(p => p.IdQuestao).HasName("COD_QUESTAO");
            builder.HasOne(p => p.Desafio).WithMany(p => p.Questoes).HasForeignKey(p => p.CodigoDesafio).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdQuestao)
                .HasColumnName("COD_QUESTAO")
                .IsRequired();

            builder.Property(p => p.CodigoDesafio)
                .HasColumnName("COD_DESAFIO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_QUESTAO")
                .IsRequired();

            // CAMPOS DE CONTROLE DE CADASTRO
            builder.Property(p => p.DataCadastro)
                .HasColumnName("DAT_CADASTRO")
                .IsRequired();

            builder.Property(p => p.CodigoUsuarioCadastro)
                .HasColumnName("COD_USUARIO_CADASTRO")
                .IsRequired();

            builder.Property(p => p.ProcessoCadastro)
                .HasColumnName("NOM_PROCESSO_CADASTRO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.DataUltimaAlteracao)
                .HasColumnName("DAT_ULTIMA_ALTERACAO");
        }
    }
}
