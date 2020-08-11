using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerFin.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    ReceitaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14, 2)", nullable: false),
                    Recebido = table.Column<bool>(type: "bit", nullable: true),
                    DataRecebido = table.Column<DateTime>(type: "datetime", nullable: true),
                    Recorrente = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.ReceitaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}
