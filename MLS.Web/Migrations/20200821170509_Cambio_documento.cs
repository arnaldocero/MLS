using Microsoft.EntityFrameworkCore.Migrations;

namespace MLS.Web.Migrations
{
    public partial class Cambio_documento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Documento",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Documento");
        }
    }
}
