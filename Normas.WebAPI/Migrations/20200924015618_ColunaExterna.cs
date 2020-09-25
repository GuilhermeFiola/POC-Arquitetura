using Microsoft.EntityFrameworkCore.Migrations;

namespace Normas.WebAPI.Migrations
{
    public partial class ColunaExterna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Externa",
                table: "NORMA",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Externa",
                table: "NORMA");
        }
    }
}
