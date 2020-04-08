using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class DesafioConfig : IEntityTypeConfiguration<Desafio>
    {
        public void Configure(EntityTypeBuilder<Desafio> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("DESAFIO");
            builder.HasKey(p => p.IdDesafio).HasName("COD_DESAFIO");
            builder.HasOne(p => p.Empresa).WithMany(p => p.Desafios).HasForeignKey(p => p.CodigoEmpresa).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Cargo).WithMany(p => p.Desafios).HasForeignKey(p => p.CodigoCargo).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdDesafio)
                .HasColumnName("COD_DESAFIO")
                .IsRequired();

            builder.Property(p => p.CodigoEmpresa)
                .HasColumnName("COD_EMPRESA")
                .IsRequired();

            builder.Property(p => p.CodigoCargo)
                .HasColumnName("COD_CARGO");

            builder.Property(p => p.Titulo)
                .HasColumnName("NOM_TITULO")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_DESAFIO")
                .IsRequired();

            builder.Property(p => p.LimiteInscricao)
                .HasColumnName("QTD_LIMITE_INSCRICAO");

            builder.Property(p => p.DataAbertura)
                .HasColumnName("DAT_ABERTURA")
                .IsRequired();

            builder.Property(p => p.DataFechamento)
                .HasColumnName("DAT_FECHAMENTO");

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
