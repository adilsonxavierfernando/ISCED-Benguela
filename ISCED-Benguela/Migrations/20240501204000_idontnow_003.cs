using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class idontnow_003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudantes_Cursos_CursoID",
                table: "Estudantes");

            migrationBuilder.RenameColumn(
                name: "CursoID",
                table: "Estudantes",
                newName: "CursosID");

            migrationBuilder.RenameIndex(
                name: "IX_Estudantes_CursoID",
                table: "Estudantes",
                newName: "IX_Estudantes_CursosID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudantes_Cursos_CursosID",
                table: "Estudantes",
                column: "CursosID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudantes_Cursos_CursosID",
                table: "Estudantes");

            migrationBuilder.RenameColumn(
                name: "CursosID",
                table: "Estudantes",
                newName: "CursoID");

            migrationBuilder.RenameIndex(
                name: "IX_Estudantes_CursosID",
                table: "Estudantes",
                newName: "IX_Estudantes_CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudantes_Cursos_CursoID",
                table: "Estudantes",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
