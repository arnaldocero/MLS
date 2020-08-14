using Microsoft.EntityFrameworkCore.Migrations;

namespace MLS.Web.Migrations
{
    public partial class Cambio_de_tipo_pdfUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documento_Document",
                table: "Documento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Documento_Document",
                table: "Documento",
                column: "Document",
                unique: true);
        }
    }
}
