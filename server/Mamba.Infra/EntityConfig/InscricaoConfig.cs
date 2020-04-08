using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class InscricaoConfig : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("INSCRICAO");
            builder.HasKey(p => p.IdInscricao).HasName("COD_INSCRICAO");
            builder.HasOne(p => p.Desafio).WithMany(p => p.Inscricoes).HasForeignKey(p => p.CodigoDesafio).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Candidato).WithMany(p => p.Inscricoes).HasForeignKey(p => p.CodigoCandidato).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdInscricao)
                .HasColumnName("COD_INSCRICAO")
                .IsRequired();

            builder.Property(p => p.CodigoDesafio)
                .HasColumnName("COD_DESAFIO")
                .IsRequired();

            builder.Property(p => p.CodigoCandidato)
                .HasColumnName("COD_CANDIDATO")
                .IsRequired();

            builder.Property(p => p.DataInscricao)
                .HasColumnName("DAT_INSCRICAO")
                .IsRequired();

            builder.Property(p => p.DataFinalizacao)
                .HasColumnName("DAT_FINALIZACAO");

            builder.Property(p => p.Resultado)
                .HasColumnName("DSC_RESULTADO")
                .HasMaxLength(500);

            builder.Property(p => p.Aprovado)
                .HasColumnName("IND_APROVADO");

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
