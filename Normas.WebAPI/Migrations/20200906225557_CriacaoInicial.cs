using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Normas.WebAPI.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NORMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    IdTipoDocumento = table.Column<int>(nullable: false),
                    IdOrgaoExpedidor = table.Column<int>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Resumo = table.Column<string>(maxLength: 250, nullable: true),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    LocalArquivoNorma = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NORMA", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NORMA");
        }
    }
}
