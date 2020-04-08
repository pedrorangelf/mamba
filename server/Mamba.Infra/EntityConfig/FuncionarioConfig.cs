using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("FUNCIONARIO");
            builder.HasKey(p => p.IdFuncionario).HasName("COD_FUNCIONARIO");
            builder.HasOne(p => p.Empresa).WithMany(p => p.Funcionarios).HasForeignKey(p => p.CodigoEmpresa).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Cargo).WithMany(p => p.Funcionarios).HasForeignKey(p => p.CodigoCargo).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Usuario).WithMany(p => p.Funcionarios).HasForeignKey(p => p.CodigoUsuario).OnDelete(DeleteBehavior.Restrict);

            // CAMPOS DA TABELA
            builder.Property(p => p.IdFuncionario)
                .HasColumnName("COD_FUNCIONARIO")
                .IsRequired();

            builder.Property(p => p.CodigoEmpresa)
                .HasColumnName("COD_EMPRESA")
                .IsRequired();

            builder.Property(p => p.CodigoCargo)
                .HasColumnName("COD_CARGO");

            builder.Property(p => p.CodigoUsuario)
                .HasColumnName("COD_USUARIO")
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
