using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // DEFINIÇÕES DA TABELA (NOME, PK E FK)
            builder.ToTable("USUARIO");
            builder.HasKey(p => p.IdUsuario).HasName("COD_USUARIO");

            // CAMPOS DA TABELA
            builder.Property(p => p.IdUsuario)
                .HasColumnName("COD_USUARIO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOM_USUARIO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DAT_NASCIMENTO")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("END_EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Celular)
                .HasColumnName("NUM_CELULAR")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.Senha)
                .HasColumnName("DSC_SENHA")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.EmailConfirmado)
                .HasColumnName("IND_EMAIL_CONFIRMADO")
                .IsRequired();

            builder.Property(p => p.Administrador)
                .HasColumnName("IND_ADMINISTRADOR")
                .IsRequired();

            builder.Property(p => p.Bloqueado)
                .HasColumnName("IND_BLOQUEADO")
                .IsRequired();

            builder.Property(p => p.MotivoBloqueio)
                .HasColumnName("DSC_MOTIVO_BLOQUEIO")
                .HasMaxLength(500);

            builder.Property(p => p.LinkLinkedin)
                .HasColumnName("DSC_LINK_LINKEDIN")
                .HasMaxLength(100);

            builder.Property(p => p.LinkGithub)
                .HasColumnName("DSC_LINK_GITHUB")
                .HasMaxLength(100);

            builder.Property(p => p.Foto)
                .HasColumnName("NOM_ARQUIVO_FOTO")
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
