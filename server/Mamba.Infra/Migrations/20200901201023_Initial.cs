using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NOM_USUARIO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    IND_BLOQUEADO = table.Column<bool>(nullable: false),
                    DSC_MOTIVO_BLOQUEIO = table.Column<string>(maxLength: 500, nullable: true),
                    DSC_LINK_LINKEDIN = table.Column<string>(maxLength: 100, nullable: true),
                    DSC_LINK_GITHUB = table.Column<string>(maxLength: 100, nullable: true),
                    NOM_ARQUIVO_FOTO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    DSC_LOGRADOURO = table.Column<string>(maxLength: 300, nullable: false),
                    NUM_ENDERECO = table.Column<string>(maxLength: 5, nullable: false),
                    DSC_COMPLEMENTO = table.Column<string>(maxLength: 10, nullable: true),
                    NOM_BAIRRO = table.Column<string>(maxLength: 300, nullable: false),
                    NOM_CIDADE = table.Column<string>(maxLength: 300, nullable: false),
                    SGL_ESTADO = table.Column<string>(maxLength: 2, nullable: false),
                    NUM_CEP = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_ENDERECO", x => x.ID_ENDERECO);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CANDIDATO",
                columns: table => new
                {
                    ID_CANDIDATO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_USUARIO = table.Column<Guid>(nullable: false),
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    DSC_PROFISSAO = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CANDIDATO", x => x.ID_CANDIDATO);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_AspNetUsers_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CANDIDATO_ENDERECO_ID_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    ID_EMPRESA = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    NOM_EMPRESA = table.Column<string>(maxLength: 500, nullable: false),
                    NUM_CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    DSC_EMPRESA = table.Column<string>(maxLength: 500, nullable: true),
                    NOM_ARQUIVO_LOGO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_EMPRESA", x => x.ID_EMPRESA);
                    table.ForeignKey(
                        name: "FK_EMPRESA_ENDERECO_ID_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CARGO",
                columns: table => new
                {
                    ID_CARGO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_EMPRESA = table.Column<Guid>(nullable: false),
                    NOM_CARGO = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CARGO", x => x.ID_CARGO);
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
                    ID_DESAFIO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_EMPRESA = table.Column<Guid>(nullable: false),
                    ID_CARGO = table.Column<Guid>(nullable: true),
                    NOM_TITULO = table.Column<string>(maxLength: 300, nullable: false),
                    DSC_DESAFIO = table.Column<string>(type: "NTEXT", nullable: false),
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
                    ID_FUNCIONARIO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_CARGO = table.Column<Guid>(nullable: false),
                    ID_USUARIO = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_FUNCIONARIO", x => x.ID_FUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_AspNetUsers_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_CARGO_ID_CARGO",
                        column: x => x.ID_CARGO,
                        principalTable: "CARGO",
                        principalColumn: "ID_CARGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INSCRICAO",
                columns: table => new
                {
                    ID_INSCRICAO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_DESAFIO = table.Column<Guid>(nullable: false),
                    ID_CANDIDATO = table.Column<Guid>(nullable: false),
                    DAT_INSCRICAO = table.Column<DateTime>(nullable: false),
                    DAT_INICIALIZACAO = table.Column<DateTime>(nullable: true),
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
                    ID_QUESTAO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_DESAFIO = table.Column<Guid>(nullable: false),
                    DSC_QUESTAO = table.Column<string>(maxLength: 300, nullable: false)
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
                    ID_RESPOSTA = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_INSCRICAO = table.Column<Guid>(nullable: false),
                    ID_QUESTAO = table.Column<Guid>(nullable: false),
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
                    ID_AVALIACAO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: true),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(maxLength: 300, nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(nullable: true),
                    ID_FUNCIONARIO = table.Column<Guid>(nullable: false),
                    ID_RESPOSTA = table.Column<Guid>(nullable: false),
                    DSC_AVALIACAO = table.Column<string>(maxLength: 300, nullable: false),
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_CANDIDATO_ID_USUARIO",
                table: "CANDIDATO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_ID_ENDERECO",
                table: "CANDIDATO",
                column: "ID_ENDERECO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_ID_EMPRESA",
                table: "CARGO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_ID_CARGO",
                table: "DESAFIO",
                column: "ID_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_DESAFIO_ID_EMPRESA",
                table: "DESAFIO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ID_ENDERECO",
                table: "EMPRESA",
                column: "ID_ENDERECO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_USUARIO",
                table: "FUNCIONARIO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_CARGO",
                table: "FUNCIONARIO",
                column: "ID_CARGO");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AVALIACAO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CARGO");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
