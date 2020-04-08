using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class RespostaConfig : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("RESPOSTA");
            builder.HasKey(p => p.IdResposta).HasName("COD_RESPOSTA");
            builder.HasOne(p => p.Inscricao).WithMany(p => p.Respostas).HasForeignKey(p => p.CodigoInscricao).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Questao).WithMany(p => p.Respostas).HasForeignKey(p => p.CodigoQuestao).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdResposta)
                .HasColumnName("COD_RESPOSTA")
                .IsRequired();

            builder.Property(p => p.CodigoInscricao)
                .HasColumnName("COD_INSCRICAO")
                .IsRequired();

            builder.Property(p => p.CodigoQuestao)
                .HasColumnName("COD_QUESTAO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_RESPOSTA")
                .HasMaxLength(500)
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
