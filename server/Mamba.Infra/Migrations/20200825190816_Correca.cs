using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class Correca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CANDIDATO_CIDADE_ID_CIDADE",
                table: "CANDIDATO");

            migrationBuilder.DropForeignKey(
                name: "FK_CARGO_AREA_ATUACAO_ID_AREA_ATUACAO",
                table: "CARGO");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPRESA_CIDADE_ID_CIDADE",
                table: "EMPRESA");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_EMPRESA_ID_EMPRESA",
                table: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "AREA_ATUACAO");

            migrationBuilder.DropTable(
                name: "CIDADE");

            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_ID_EMPRESA",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_ID_CIDADE",
                table: "EMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_CARGO_ID_AREA_ATUACAO",
                table: "CARGO");

            migrationBuilder.DropIndex(
                name: "IX_CANDIDATO_ID_CIDADE",
                table: "CANDIDATO");

            migrationBuilder.DropColumn(
                name: "ID_EMPRESA",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "ID_CIDADE",
                table: "EMPRESA");

            migrationBuilder.DropColumn(
                name: "ID_AREA_ATUACAO",
                table: "CARGO");

            migrationBuilder.DropColumn(
                name: "ID_CIDADE",
                table: "CANDIDATO");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_CARGO",
                table: "FUNCIONARIO",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ID_ENDERECO",
                table: "EMPRESA",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_ENDERECO",
                table: "CANDIDATO",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ID_ENDERECO",
                table: "EMPRESA",
                column: "ID_ENDERECO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_ID_ENDERECO",
                table: "CANDIDATO",
                column: "ID_ENDERECO",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CANDIDATO_ENDERECO_ID_ENDERECO",
                table: "CANDIDATO",
                column: "ID_ENDERECO",
                principalTable: "ENDERECO",
                principalColumn: "ID_ENDERECO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPRESA_ENDERECO_ID_ENDERECO",
                table: "EMPRESA",
                column: "ID_ENDERECO",
                principalTable: "ENDERECO",
                principalColumn: "ID_ENDERECO",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CANDIDATO_ENDERECO_ID_ENDERECO",
                table: "CANDIDATO");

            migrationBuilder.DropForeignKey(
                name: "FK_EMPRESA_ENDERECO_ID_ENDERECO",
                table: "EMPRESA");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_ID_ENDERECO",
                table: "EMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_CANDIDATO_ID_ENDERECO",
                table: "CANDIDATO");

            migrationBuilder.DropColumn(
                name: "ID_ENDERECO",
                table: "EMPRESA");

            migrationBuilder.DropColumn(
                name: "ID_ENDERECO",
                table: "CANDIDATO");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_CARGO",
                table: "FUNCIONARIO",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_EMPRESA",
                table: "FUNCIONARIO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_CIDADE",
                table: "EMPRESA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_AREA_ATUACAO",
                table: "CARGO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID_CIDADE",
                table: "CANDIDATO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AREA_ATUACAO",
                columns: table => new
                {
                    ID_AREA_ATUACAO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DSC_AREA_ATUACAO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_AREA_ATUACAO", x => x.ID_AREA_ATUACAO);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    ID_ESTADO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOM_ESTADO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SGL_ESTADO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_ESTADO", x => x.ID_ESTADO);
                });

            migrationBuilder.CreateTable(
                name: "CIDADE",
                columns: table => new
                {
                    ID_CIDADE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DAT_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DAT_ULTIMA_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ID_ESTADO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOM_CIDADE = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    NOM_PROCESSO_CADASTRO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SGL_CIDADE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ID_USUARIO_CADASTRO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ID_EMPRESA",
                table: "FUNCIONARIO",
                column: "ID_EMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ID_CIDADE",
                table: "EMPRESA",
                column: "ID_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_CARGO_ID_AREA_ATUACAO",
                table: "CARGO",
                column: "ID_AREA_ATUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_CANDIDATO_ID_CIDADE",
                table: "CANDIDATO",
                column: "ID_CIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_CIDADE_ID_ESTADO",
                table: "CIDADE",
                column: "ID_ESTADO");

            migrationBuilder.AddForeignKey(
                name: "FK_CANDIDATO_CIDADE_ID_CIDADE",
                table: "CANDIDATO",
                column: "ID_CIDADE",
                principalTable: "CIDADE",
                principalColumn: "ID_CIDADE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CARGO_AREA_ATUACAO_ID_AREA_ATUACAO",
                table: "CARGO",
                column: "ID_AREA_ATUACAO",
                principalTable: "AREA_ATUACAO",
                principalColumn: "ID_AREA_ATUACAO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMPRESA_CIDADE_ID_CIDADE",
                table: "EMPRESA",
                column: "ID_CIDADE",
                principalTable: "CIDADE",
                principalColumn: "ID_CIDADE",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_EMPRESA_ID_EMPRESA",
                table: "FUNCIONARIO",
                column: "ID_EMPRESA",
                principalTable: "EMPRESA",
                principalColumn: "ID_EMPRESA",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
