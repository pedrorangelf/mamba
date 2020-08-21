using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AREA_ATUACAO",
                columns: table => new
                {
                    ID_AREA_ATUACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    DSC_AREA_ATUACAO = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_AREA_ATUACAO", x => x.ID_AREA_ATUACAO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    ID_ESTADO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    EstadoId = table.Column<int>(nullable: false),
                    NOM_ESTADO = table.Column<string>(maxLength: 500, nullable: false),
                    SGL_ESTADO = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_ESTADO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    NOM_USUARIO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    END_EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    NUM_CELULAR = table.Column<string>(maxLength: 14, nullable: false),
                    DSC_SENHA = table.Column<string>(maxLength: 500, nullable: false),
                    IND_EMAIL_CONFIRMADO = table.Column<bool>(nullable: false),
                    IND_ADMINISTRADOR = table.Column<bool>(nullable: false),
                    IND_BLOQUEADO = table.Column<bool>(nullable: false),
                    DSC_MOTIVO_BLOQUEIO = table.Column<string>(maxLength: 500, nullable: true),
                    DSC_LINK_LINKEDIN = table.Column<string>(maxLength: 100, nullable: true),
                    DSC_LINK_GITHUB = table.Column<string>(maxLength: 100, nullable: true),
                    NOM_ARQUIVO_FOTO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    ID_CIDADE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_ESTADO = table.Column<int>(nullable: false),
                    NOM_CIDADE = table.Column<string>(maxLength: 500, nullable: false),
                    SGL_CIDADE = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CIDADE", x => x.ID_CIDADE);
                    table.ForeignKey(
                        name: "FK_CIDADE_ESTADO_ID_ESTADO",
                        column: x => x.ID_ESTADO,
                        principalTable: "ESTADO",
                        principalColumn: "ID_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CANDIDATO",
                columns: table => new
                {
                    ID_CANDIDATO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_USUARIO = table.Column<int>(nullable: false),
                    ID_CIDADE = table.Column<int>(nullable: false),
                    DSC_PROFISSAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CANDIDATO", x => x.ID_CANDIDATO);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_CIDADE_ID_CIDADE",
                        column: x => x.ID_CIDADE,
                        principalTable: "CIDADE",
                        principalColumn: "ID_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    ID_EMPRESA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_CIDADE = table.Column<int>(nullable: false),
                    NOM_EMPRESA = table.Column<string>(maxLength: 500, nullable: false),
                    NUM_CNPJ = table.Column<string>(maxLength: 18, nullable: false),
                    DSC_EMPRESA = table.Column<string>(maxLength: 500, nullable: true),
                    NOM_ARQUIVO_LOGO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_EMPRESA", x => x.ID_EMPRESA);
                    table.ForeignKey(
                        name: "FK_EMPRESA_CIDADE_ID_CIDADE",
                        column: x => x.ID_CIDADE,
                        principalTable: "CIDADE",
                        principalColumn: "ID_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARGO",
                columns: table => new
                {
                    ID_CARGO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: false),
                    ID_AREA_ATUACAO = table.Column<int>(nullable: false),
                    NOM_CARGO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CARGO", x => x.ID_CARGO);
                    table.ForeignKey(
                        name: "FK_CARGO_AREA_ATUACAO_ID_AREA_ATUACAO",
                        column: x => x.ID_AREA_ATUACAO,
                        principalTable: "AREA_ATUACAO",
                        principalColumn: "ID_AREA_ATUACAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARGO_EMPRESA_ID_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESAFIO",
                columns: table => new
                {
                    ID_DESAFIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: false),
                    ID_CARGO = table.Column<int>(nullable: true),
                    NOM_TITULO = table.Column<string>(nullable: false),
                    DSC_DESAFIO = table.Column<string>(nullable: false),
                    QTD_LIMITE_INSCRICAO = table.Column<int>(nullable: true),
                    DAT_ABERTURA = table.Column<DateTime>(nullable: false),
                    DAT_FECHAMENTO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_DESAFIO", x => x.ID_DESAFIO);
                    table.ForeignKey(
                        name: "FK_DESAFIO_CARGO_ID_CARGO",
                        column: x => x.ID_CARGO,
                        principalTable: "CARGO",
                        principalColumn: "ID_CARGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DESAFIO_EMPRESA_ID_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    ID_FUNCIONARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_EMPRESA = table.Column<int>(nullable: false),
                    ID_CARGO = table.Column<int>(nullable: true),
                    ID_USUARIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_FUNCIONARIO", x => x.ID_FUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_CARGO_ID_CARGO",
                        column: x => x.ID_CARGO,
                        principalTable: "CARGO",
                        principalColumn: "ID_CARGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_EMPRESA_ID_EMPRESA",
                        column: x => x.ID_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "ID_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO",
                columns: table => new
                {
                    ID_INSCRICAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_DESAFIO = table.Column<int>(nullable: false),
                    ID_CANDIDATO = table.Column<int>(nullable: false),
                    DAT_INSCRICAO = table.Column<DateTime>(nullable: false),
                    DAT_FINALIZACAO = table.Column<DateTime>(nullable: true),
                    DSC_RESULTADO = table.Column<string>(maxLength: 500, nullable: true),
                    IND_APROVADO = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_INSCRICAO", x => x.ID_INSCRICAO);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_CANDIDATO_ID_CANDIDATO",
                        column: x => x.ID_CANDIDATO,
                        principalTable: "CANDIDATO",
                        principalColumn: "ID_CANDIDATO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_DESAFIO_ID_DESAFIO",
                        column: x => x.ID_DESAFIO,
                        principalTable: "DESAFIO",
                        principalColumn: "ID_DESAFIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QUESTAO",
                columns: table => new
                {
                    ID_QUESTAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_DESAFIO = table.Column<int>(nullable: false),
                    DSC_QUESTAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_QUESTAO", x => x.ID_QUESTAO);
                    table.ForeignKey(
                        name: "FK_QUESTAO_DESAFIO_ID_DESAFIO",
                        column: x => x.ID_DESAFIO,
                        principalTable: "DESAFIO",
                        principalColumn: "ID_DESAFIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESPOSTA",
                columns: table => new
                {
                    ID_RESPOSTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_INSCRICAO = table.Column<int>(nullable: false),
                    ID_QUESTAO = table.Column<int>(nullable: false),
                    DSC_RESPOSTA = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_RESPOSTA", x => x.ID_RESPOSTA);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_INSCRICAO_ID_INSCRICAO",
                        column: x => x.ID_INSCRICAO,
                        principalTable: "INSCRICAO",
                        principalColumn: "ID_INSCRICAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_QUESTAO_ID_QUESTAO",
                        column: x => x.ID_QUESTAO,
                        principalTable: "QUESTAO",
                        principalColumn: "ID_QUESTAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AVALIACAO",
                columns: table => new
                {
                    ID_AVALIACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_FUNCIONARIO = table.Column<int>(nullable: false),
                    ID_RESPOSTA = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IND_APROVADO = table.Column<bool>(nullable: false),
                    NUM_NOTA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_AVALIACAO", x => x.ID_AVALIACAO);
                    table.ForeignKey(
                        name: "FK_AVALIACAO_FUNCIONARIO_ID_FUNCIONARIO",
                        column: x => x.ID_FUNCIONARIO,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID_FUNCIONARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AVALIACAO_RESPOSTA_ID_RESPOSTA",
                        column: x => x.ID_RESPOSTA,
                        principalTable: "RESPOSTA",
                        principalColumn: "ID_RESPOSTA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AVALIACAO_ID_FUNCIONARIO",
                table: "AVALIACAO",
                column: "ID_FUNCIONARIO");

            migrationBuilder.CreateIndex(
                name: "IX_AVALIACAO_ID_RESPOSTA",
                table: "AVALIACAO",
                column: "ID_RESPOSTA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_ID_CIDADE",
                table: "CANDIDATO",
                column: "ID_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_ID_USUARIO",
                table: "CANDIDATO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_ID_AREA_ATUACAO",
                table: "CARGO",
                column: "ID_AREA_ATUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_ID_EMPRESA",
                table: "CARGO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_ID_ESTADO",
                table: "CIDADE",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_ID_CARGO",
                table: "DESAFIO",
                column: "ID_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_ID_EMPRESA",
                table: "DESAFIO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ID_CIDADE",
                table: "EMPRESA",
                column: "ID_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_CARGO",
                table: "FUNCIONARIO",
                column: "ID_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_EMPRESA",
                table: "FUNCIONARIO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_USUARIO",
                table: "FUNCIONARIO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_ID_CANDIDATO",
                table: "INSCRICAO",
                column: "ID_CANDIDATO");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_ID_DESAFIO",
                table: "INSCRICAO",
                column: "ID_DESAFIO");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTAO_ID_DESAFIO",
                table: "QUESTAO",
                column: "ID_DESAFIO");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_ID_INSCRICAO",
                table: "RESPOSTA",
                column: "ID_INSCRICAO");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_ID_QUESTAO",
                table: "RESPOSTA",
                column: "ID_QUESTAO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "RESPOSTA");

            migrationBuilder.DropTable(
                name: "INSCRICAO");

            migrationBuilder.DropTable(
                name: "QUESTAO");

            migrationBuilder.DropTable(
                name: "CANDIDATO");

            migrationBuilder.DropTable(
                name: "DESAFIO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "CARGO");

            migrationBuilder.DropTable(
                name: "AREA_ATUACAO");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "CIDADE");

            migrationBuilder.DropTable(
                name: "ESTADO");
        }
    }
}
