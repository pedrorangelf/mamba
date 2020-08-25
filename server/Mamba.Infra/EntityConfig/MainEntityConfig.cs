using Mamba.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mamba.Infra.EntityConfig
{
    public static class MainEntityConfig
    {

        public static EntityTypeBuilder<TEntity> SetMainEntityConfig<TEntity>(this EntityTypeBuilder<TEntity> builder, string tableName)
            where TEntity : MainEntity
        {
            builder.ToTable(tableName);
            builder.HasKey(p => p.Id).HasName("ID_" + tableName);

            builder.Property(p => p.Id)
                .HasColumnName("ID_" + tableName)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DAT_CADASTRO")
                .IsRequired();

            builder.Property(p => p.UsuarioCadastroId)
                .HasColumnName("ID_USUARIO_CADASTRO");

            builder.Property(p => p.ProcessoCadastro)
                .HasColumnName("NOM_PROCESSO_CADASTRO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.DataUltimaAlteracao)
                .HasColumnName("DAT_ULTIMA_ALTERACAO");


            return builder;
        }

    }
}
