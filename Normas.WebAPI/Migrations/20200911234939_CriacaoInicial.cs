using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Normas.WebAPI.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORGAOEXPEDIDOR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGAOEXPEDIDOR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TIPODOCUMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPODOCUMENTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NORMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoNorma = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    IdTipoDocumento = table.Column<int>(nullable: false),
                    IdOrgaoExpedidor = table.Column<int>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Resumo = table.Column<string>(maxLength: 250, nullable: true),
                    Observacao = table.Column<string>(maxLength: 250, nullable: true),
                    LocalArquivoNormas = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NORMA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NORMA_ORGAOEXPEDIDOR_IdOrgaoExpedidor",
                        column: x => x.IdOrgaoExpedidor,
                        principalTable: "ORGAOEXPEDIDOR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NORMA_TIPODOCUMENTO_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TIPODOCUMENTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ORGAOEXPEDIDOR",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Indefinido" });

            migrationBuilder.InsertData(
                table: "ORGAOEXPEDIDOR",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "ABNT" });

            migrationBuilder.InsertData(
                table: "ORGAOEXPEDIDOR",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "ISO" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 1, "Indefinido" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 2, "Norma de Base" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 3, "Norma de Terminologia" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 4, "Norma de Ensaio" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 5, "Norma de Produto" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 6, "Norma de Processo" });

            migrationBuilder.InsertData(
                table: "TIPODOCUMENTO",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 7, "Norma de Serviço" });

            migrationBuilder.CreateIndex(
                name: "IX_NORMA_CodigoNorma",
                table: "NORMA",
                column: "CodigoNorma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NORMA_IdOrgaoExpedidor",
                table: "NORMA",
                column: "IdOrgaoExpedidor");

            migrationBuilder.CreateIndex(
                name: "IX_NORMA_IdTipoDocumento",
                table: "NORMA",
                column: "IdTipoDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NORMA");

            migrationBuilder.DropTable(
                name: "ORGAOEXPEDIDOR");

            migrationBuilder.DropTable(
                name: "TIPODOCUMENTO");
        }
    }
}
