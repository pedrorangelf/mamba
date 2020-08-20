using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.SetMainEntityConfig("USUARIO");

            // CAMPOS DA TABELA
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
        }
    }
}
