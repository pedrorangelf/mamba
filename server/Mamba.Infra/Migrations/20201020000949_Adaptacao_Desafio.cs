using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class Adaptacao_Desafio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSC_DESAFIO",
                table: "DESAFIO");

            migrationBuilder.DropColumn(
                name: "NOM_TITULO",
                table: "DESAFIO");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_CARGO",
                table: "DESAFIO",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID_CARGO",
                table: "DESAFIO",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "DSC_DESAFIO",
                table: "DESAFIO",
                type: "NTEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NOM_TITULO",
                table: "DESAFIO",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
