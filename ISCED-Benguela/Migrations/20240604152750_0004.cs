using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class _0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disicplina_Departamentos_DepartamentoID",
                table: "Disicplina");

            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Disicplina",
                newName: "CursoID");

            migrationBuilder.RenameIndex(
                name: "IX_Disicplina_DepartamentoID",
                table: "Disicplina",
                newName: "IX_Disicplina_CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disicplina_Cursos_CursoID",
                table: "Disicplina",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disicplina_Cursos_CursoID",
                table: "Disicplina");

            migrationBuilder.RenameColumn(
                name: "CursoID",
                table: "Disicplina",
                newName: "DepartamentoID");

            migrationBuilder.RenameIndex(
                name: "IX_Disicplina_CursoID",
                table: "Disicplina",
                newName: "IX_Disicplina_DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disicplina_Departamentos_DepartamentoID",
                table: "Disicplina",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
