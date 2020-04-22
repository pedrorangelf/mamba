using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("EMPRESA");
            builder.HasKey(p => p.IdEmpresa).HasName("COD_EMPRESA");
            builder.HasOne(p => p.Cidade).WithMany(p => p.Empresas).HasForeignKey(p => p.CodigoCidade).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdEmpresa)
                .HasColumnName("COD_EMPRESA")
                .IsRequired();

            builder.Property(p => p.CodigoCidade)
                .HasColumnName("COD_CIDADE")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_EMPRESA")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.CNPJ)
                .HasColumnName("NUM_CNPJ")
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("DSC_EMPRESA")
                .HasMaxLength(500);

            builder.Property(p => p.Logo)
                .HasColumnName("NOM_ARQUIVO_LOGO")
                .HasMaxLength(200);

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
