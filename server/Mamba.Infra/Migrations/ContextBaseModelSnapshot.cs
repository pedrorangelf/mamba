﻿// <auto-generated />
using System;
using Mamba.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mamba.Infra.Migrations
{
    [DbContext(typeof(ContextBase))]
    partial class ContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mamba.Domain.Entities.AreaAtuacao", b =>
                {
                    b.Property<int>("IdAreaAtuacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_AREA_ATUACAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_AREA_ATUACAO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdAreaAtuacao")
                        .HasName("COD_AREA_ATUACAO");

                    b.ToTable("AREA_ATUACAO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("IdAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_AVALIACAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprovado")
                        .HasColumnName("IND_APROVADO")
                        .HasColumnType("bit");

                    b.Property<int>("CodigoFuncionario")
                        .HasColumnName("COD_FUNCIONARIO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoResposta")
                        .HasColumnName("COD_RESPOSTA")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nota")
                        .HasColumnName("NUM_NOTA")
                        .HasColumnType("int");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdAvaliacao")
                        .HasName("COD_AVALIACAO");

                    b.HasIndex("CodigoFuncionario");

                    b.HasIndex("CodigoResposta")
                        .IsUnique();

                    b.ToTable("AVALIACAO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_CANDIDATO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoCidade")
                        .HasColumnName("COD_CIDADE")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("COD_USUARIO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnName("DSC_PROFISSAO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCandidato")
                        .HasName("COD_CANDIDATO");

                    b.HasIndex("CodigoCidade");

                    b.HasIndex("CodigoUsuario");

                    b.ToTable("CANDIDATO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_CARGO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoAreaAtuacao")
                        .HasColumnName("COD_AREA_ATUACAO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoEmpresa")
                        .HasColumnName("COD_EMPRESA")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_CARGO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdCargo")
                        .HasName("COD_CARGO");

                    b.HasIndex("CodigoAreaAtuacao");

                    b.HasIndex("CodigoEmpresa");

                    b.ToTable("CARGO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Cidade", b =>
                {
                    b.Property<int>("IdCidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_CIDADE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoEstado")
                        .HasColumnName("COD_ESTADO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_CIDADE")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("SGL_CIDADE")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.HasKey("IdCidade")
                        .HasName("COD_CIDADE");

                    b.HasIndex("CodigoEstado");

                    b.ToTable("CIDADE");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Desafio", b =>
                {
                    b.Property<int>("IdDesafio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_DESAFIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodigoCargo")
                        .HasColumnName("COD_CARGO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoEmpresa")
                        .HasColumnName("COD_EMPRESA")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnName("DAT_ABERTURA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnName("DAT_FECHAMENTO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_DESAFIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LimiteInscricao")
                        .HasColumnName("QTD_LIMITE_INSCRICAO")
                        .HasColumnType("int");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("NOM_TITULO")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDesafio")
                        .HasName("COD_DESAFIO");

                    b.HasIndex("CodigoCargo");

                    b.HasIndex("CodigoEmpresa");

                    b.ToTable("DESAFIO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_EMPRESA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("NUM_CNPJ")
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<int>("CodigoCidade")
                        .HasColumnName("COD_CIDADE")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnName("DSC_EMPRESA")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Logo")
                        .HasColumnName("NOM_ARQUIVO_LOGO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_EMPRESA")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdEmpresa")
                        .HasName("COD_EMPRESA");

                    b.HasIndex("CodigoCidade");

                    b.ToTable("EMPRESA");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_ESTADO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_ESTADO")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnName("SGL_ESTADO")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("IdEstado")
                        .HasName("COD_ESTADO");

                    b.ToTable("ESTADO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_FUNCIONARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CodigoCargo")
                        .HasColumnName("COD_CARGO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoEmpresa")
                        .HasColumnName("COD_EMPRESA")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnName("COD_USUARIO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdFuncionario")
                        .HasName("COD_FUNCIONARIO");

                    b.HasIndex("CodigoCargo");

                    b.HasIndex("CodigoEmpresa");

                    b.HasIndex("CodigoUsuario");

                    b.ToTable("FUNCIONARIO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Inscricao", b =>
                {
                    b.Property<int>("IdInscricao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_INSCRICAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Aprovado")
                        .HasColumnName("IND_APROVADO")
                        .HasColumnType("bit");

                    b.Property<int>("CodigoCandidato")
                        .HasColumnName("COD_CANDIDATO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoDesafio")
                        .HasColumnName("COD_DESAFIO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFinalizacao")
                        .HasColumnName("DAT_FINALIZACAO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnName("DAT_INSCRICAO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Resultado")
                        .HasColumnName("DSC_RESULTADO")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("IdInscricao")
                        .HasName("COD_INSCRICAO");

                    b.HasIndex("CodigoCandidato");

                    b.HasIndex("CodigoDesafio");

                    b.ToTable("INSCRICAO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Questao", b =>
                {
                    b.Property<int>("IdQuestao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_QUESTAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoDesafio")
                        .HasColumnName("COD_DESAFIO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_QUESTAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdQuestao")
                        .HasName("COD_QUESTAO");

                    b.HasIndex("CodigoDesafio");

                    b.ToTable("QUESTAO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Resposta", b =>
                {
                    b.Property<int>("IdResposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_RESPOSTA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoInscricao")
                        .HasColumnName("COD_INSCRICAO")
                        .HasColumnType("int");

                    b.Property<int>("CodigoQuestao")
                        .HasColumnName("COD_QUESTAO")
                        .HasColumnType("int");

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DSC_RESPOSTA")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("IdResposta")
                        .HasName("COD_RESPOSTA");

                    b.HasIndex("CodigoInscricao");

                    b.HasIndex("CodigoQuestao");

                    b.ToTable("RESPOSTA");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("COD_USUARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Administrador")
                        .HasColumnName("IND_ADMINISTRADOR")
                        .HasColumnType("bit");

                    b.Property<bool>("Bloqueado")
                        .HasColumnName("IND_BLOQUEADO")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnName("NUM_CELULAR")
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<int?>("CodigoUsuarioCadastro")
                        .IsRequired()
                        .HasColumnName("COD_USUARIO_CADASTRO")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("DAT_CADASTRO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DAT_NASCIMENTO")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAlteracao")
                        .HasColumnName("DAT_ULTIMA_ALTERACAO")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("END_EMAIL")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnName("IND_EMAIL_CONFIRMADO")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .HasColumnName("NOM_ARQUIVO_FOTO")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LinkGithub")
                        .HasColumnName("DSC_LINK_GITHUB")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LinkLinkedin")
                        .HasColumnName("DSC_LINK_LINKEDIN")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MotivoBloqueio")
                        .HasColumnName("DSC_MOTIVO_BLOQUEIO")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOM_USUARIO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ProcessoCadastro")
                        .IsRequired()
                        .HasColumnName("NOM_PROCESSO_CADASTRO")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("DSC_SENHA")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("IdUsuario")
                        .HasName("COD_USUARIO");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("CodigoFuncionario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Resposta", "Resposta")
                        .WithOne("Avaliacao")
                        .HasForeignKey("Mamba.Domain.Entities.Avaliacao", "CodigoResposta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Candidato", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Cidade", "Cidade")
                        .WithMany("Candidatos")
                        .HasForeignKey("CodigoCidade")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Candidatos")
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Cargo", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.AreaAtuacao", "AreaAtuacao")
                        .WithMany("Cargos")
                        .HasForeignKey("CodigoAreaAtuacao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Cargos")
                        .HasForeignKey("CodigoEmpresa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Cidade", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("CodigoEstado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Desafio", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Desafios")
                        .HasForeignKey("CodigoCargo")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mamba.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Desafios")
                        .HasForeignKey("CodigoEmpresa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Empresa", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Cidade", "Cidade")
                        .WithMany("Empresas")
                        .HasForeignKey("CodigoCidade")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Cargo", "Cargo")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CodigoCargo")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mamba.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CodigoEmpresa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Funcionarios")
                        .HasForeignKey("CodigoUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Inscricao", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Candidato", "Candidato")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CodigoCandidato")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Desafio", "Desafio")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CodigoDesafio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Questao", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Desafio", "Desafio")
                        .WithMany("Questoes")
                        .HasForeignKey("CodigoDesafio")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Mamba.Domain.Entities.Resposta", b =>
                {
                    b.HasOne("Mamba.Domain.Entities.Inscricao", "Inscricao")
                        .WithMany("Respostas")
                        .HasForeignKey("CodigoInscricao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mamba.Domain.Entities.Questao", "Questao")
                        .WithMany("Respostas")
                        .HasForeignKey("CodigoQuestao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
