using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AREA_ATUACAO",
                columns: table => new
                {
                    COD_AREA_ATUACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DSC_AREA_ATUACAO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_AREA_ATUACAO", x => x.COD_AREA_ATUACAO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    COD_ESTADO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOM_ESTADO = table.Column<string>(maxLength: 500, nullable: false),
                    SGL_ESTADO = table.Column<string>(maxLength: 2, nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_ESTADO", x => x.COD_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    COD_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    NOM_ARQUIVO_FOTO = table.Column<string>(maxLength: 200, nullable: true),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_USUARIO", x => x.COD_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    COD_CIDADE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_ESTADO = table.Column<int>(nullable: false),
                    NOM_CIDADE = table.Column<string>(maxLength: 500, nullable: false),
                    SGL_CIDADE = table.Column<string>(maxLength: 3, nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_CIDADE", x => x.COD_CIDADE);
                    table.ForeignKey(
                        name: "FK_CIDADE_ESTADO_COD_ESTADO",
                        column: x => x.COD_ESTADO,
                        principalTable: "ESTADO",
                        principalColumn: "COD_ESTADO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CANDIDATO",
                columns: table => new
                {
                    COD_CANDIDATO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_USUARIO = table.Column<int>(nullable: false),
                    COD_CIDADE = table.Column<int>(nullable: false),
                    DSC_PROFISSAO = table.Column<string>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_CANDIDATO", x => x.COD_CANDIDATO);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_CIDADE_COD_CIDADE",
                        column: x => x.COD_CIDADE,
                        principalTable: "CIDADE",
                        principalColumn: "COD_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_USUARIO_COD_USUARIO",
                        column: x => x.COD_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "COD_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    COD_EMPRESA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_CIDADE = table.Column<int>(nullable: false),
                    NOM_EMPRESA = table.Column<string>(maxLength: 500, nullable: false),
                    NUM_CNPJ = table.Column<int>(nullable: false),
                    DSC_EMPRESA = table.Column<string>(maxLength: 500, nullable: true),
                    NOM_ARQUIVO_LOGO = table.Column<string>(maxLength: 200, nullable: true),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_EMPRESA", x => x.COD_EMPRESA);
                    table.ForeignKey(
                        name: "FK_EMPRESA_CIDADE_COD_CIDADE",
                        column: x => x.COD_CIDADE,
                        principalTable: "CIDADE",
                        principalColumn: "COD_CIDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARGO",
                columns: table => new
                {
                    COD_CARGO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_EMPRESA = table.Column<int>(nullable: false),
                    COD_AREA_ATUACAO = table.Column<int>(nullable: false),
                    NOM_CARGO = table.Column<string>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_CARGO", x => x.COD_CARGO);
                    table.ForeignKey(
                        name: "FK_CARGO_AREA_ATUACAO_COD_AREA_ATUACAO",
                        column: x => x.COD_AREA_ATUACAO,
                        principalTable: "AREA_ATUACAO",
                        principalColumn: "COD_AREA_ATUACAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CARGO_EMPRESA_COD_EMPRESA",
                        column: x => x.COD_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "COD_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESAFIO",
                columns: table => new
                {
                    COD_DESAFIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_EMPRESA = table.Column<int>(nullable: false),
                    COD_CARGO = table.Column<int>(nullable: true),
                    NOM_TITULO = table.Column<string>(nullable: false),
                    DSC_DESAFIO = table.Column<string>(nullable: false),
                    QTD_LIMITE_INSCRICAO = table.Column<int>(nullable: true),
                    DAT_ABERTURA = table.Column<DateTime>(nullable: false),
                    DAT_FECHAMENTO = table.Column<DateTime>(nullable: true),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_DESAFIO", x => x.COD_DESAFIO);
                    table.ForeignKey(
                        name: "FK_DESAFIO_CARGO_COD_CARGO",
                        column: x => x.COD_CARGO,
                        principalTable: "CARGO",
                        principalColumn: "COD_CARGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DESAFIO_EMPRESA_COD_EMPRESA",
                        column: x => x.COD_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "COD_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    COD_FUNCIONARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_EMPRESA = table.Column<int>(nullable: false),
                    COD_CARGO = table.Column<int>(nullable: true),
                    COD_USUARIO = table.Column<int>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_FUNCIONARIO", x => x.COD_FUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_CARGO_COD_CARGO",
                        column: x => x.COD_CARGO,
                        principalTable: "CARGO",
                        principalColumn: "COD_CARGO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_EMPRESA_COD_EMPRESA",
                        column: x => x.COD_EMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "COD_EMPRESA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_USUARIO_COD_USUARIO",
                        column: x => x.COD_USUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "COD_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO",
                columns: table => new
                {
                    COD_INSCRICAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_DESAFIO = table.Column<int>(nullable: false),
                    COD_CANDIDATO = table.Column<int>(nullable: false),
                    DAT_INSCRICAO = table.Column<DateTime>(nullable: false),
                    DAT_FINALIZACAO = table.Column<DateTime>(nullable: true),
                    DSC_RESULTADO = table.Column<string>(maxLength: 500, nullable: true),
                    IND_APROVADO = table.Column<bool>(nullable: true),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_INSCRICAO", x => x.COD_INSCRICAO);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_CANDIDATO_COD_CANDIDATO",
                        column: x => x.COD_CANDIDATO,
                        principalTable: "CANDIDATO",
                        principalColumn: "COD_CANDIDATO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSCRICAO_DESAFIO_COD_DESAFIO",
                        column: x => x.COD_DESAFIO,
                        principalTable: "DESAFIO",
                        principalColumn: "COD_DESAFIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QUESTAO",
                columns: table => new
                {
                    COD_QUESTAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_DESAFIO = table.Column<int>(nullable: false),
                    DSC_QUESTAO = table.Column<string>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_QUESTAO", x => x.COD_QUESTAO);
                    table.ForeignKey(
                        name: "FK_QUESTAO_DESAFIO_COD_DESAFIO",
                        column: x => x.COD_DESAFIO,
                        principalTable: "DESAFIO",
                        principalColumn: "COD_DESAFIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESPOSTA",
                columns: table => new
                {
                    COD_RESPOSTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_INSCRICAO = table.Column<int>(nullable: false),
                    COD_QUESTAO = table.Column<int>(nullable: false),
                    DSC_RESPOSTA = table.Column<string>(maxLength: 500, nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_RESPOSTA", x => x.COD_RESPOSTA);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_INSCRICAO_COD_INSCRICAO",
                        column: x => x.COD_INSCRICAO,
                        principalTable: "INSCRICAO",
                        principalColumn: "COD_INSCRICAO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESPOSTA_QUESTAO_COD_QUESTAO",
                        column: x => x.COD_QUESTAO,
                        principalTable: "QUESTAO",
                        principalColumn: "COD_QUESTAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AVALIACAO",
                columns: table => new
                {
                    COD_AVALIACAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COD_FUNCIONARIO = table.Column<int>(nullable: false),
                    COD_RESPOSTA = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IND_APROVADO = table.Column<bool>(nullable: false),
                    NUM_NOTA = table.Column<int>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    COD_USUARIO_CADASTRO = table.Column<int>(nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("COD_AVALIACAO", x => x.COD_AVALIACAO);
                    table.ForeignKey(
                        name: "FK_AVALIACAO_FUNCIONARIO_COD_FUNCIONARIO",
                        column: x => x.COD_FUNCIONARIO,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "COD_FUNCIONARIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AVALIACAO_RESPOSTA_COD_RESPOSTA",
                        column: x => x.COD_RESPOSTA,
                        principalTable: "RESPOSTA",
                        principalColumn: "COD_RESPOSTA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AVALIACAO_COD_FUNCIONARIO",
                table: "AVALIACAO",
                column: "COD_FUNCIONARIO");

            migrationBuilder.CreateIndex(
                name: "IX_AVALIACAO_COD_RESPOSTA",
                table: "AVALIACAO",
                column: "COD_RESPOSTA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_COD_CIDADE",
                table: "CANDIDATO",
                column: "COD_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_COD_USUARIO",
                table: "CANDIDATO",
                column: "COD_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_COD_AREA_ATUACAO",
                table: "CARGO",
                column: "COD_AREA_ATUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_COD_EMPRESA",
                table: "CARGO",
                column: "COD_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_COD_ESTADO",
                table: "CIDADE",
                column: "COD_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_COD_CARGO",
                table: "DESAFIO",
                column: "COD_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_COD_EMPRESA",
                table: "DESAFIO",
                column: "COD_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_COD_CIDADE",
                table: "EMPRESA",
                column: "COD_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_COD_CARGO",
                table: "FUNCIONARIO",
                column: "COD_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_COD_EMPRESA",
                table: "FUNCIONARIO",
                column: "COD_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_COD_USUARIO",
                table: "FUNCIONARIO",
                column: "COD_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_COD_CANDIDATO",
                table: "INSCRICAO",
                column: "COD_CANDIDATO");

            migrationBuilder.CreateIndex(
                name: "IX_INSCRICAO_COD_DESAFIO",
                table: "INSCRICAO",
                column: "COD_DESAFIO");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTAO_COD_DESAFIO",
                table: "QUESTAO",
                column: "COD_DESAFIO");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_COD_INSCRICAO",
                table: "RESPOSTA",
                column: "COD_INSCRICAO");

            migrationBuilder.CreateIndex(
                name: "IX_RESPOSTA_COD_QUESTAO",
                table: "RESPOSTA",
                column: "COD_QUESTAO");
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
