using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NormasExternas.API.Migrations
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
                    CodigoNorma = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<string>(nullable: false),
                    OrgaoExpedidor = table.Column<string>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    DataHoraInclusao = table.Column<DateTime>(nullable: false),
                    Resumo = table.Column<string>(maxLength: 250, nullable: true),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    LocalArquivoNormas = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NORMA", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NORMA_CodigoNorma",
                table: "NORMA",
                column: "CodigoNorma",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NORMA");
        }
    }
}
