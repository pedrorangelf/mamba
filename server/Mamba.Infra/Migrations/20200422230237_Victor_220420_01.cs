using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamba.Infra.Migrations
{
    public partial class Victor_220420_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NUM_CNPJ",
                table: "EMPRESA",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NUM_CNPJ",
                table: "EMPRESA",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 18);
        }
    }
}
