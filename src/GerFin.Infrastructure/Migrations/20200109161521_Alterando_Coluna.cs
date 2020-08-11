using Microsoft.EntityFrameworkCore.Migrations;

namespace GerFin.Infrastructure.Migrations
{
    public partial class Alterando_Coluna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Recebido",
                table: "Receita",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Recebido",
                table: "Receita",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");
        }
    }
}
