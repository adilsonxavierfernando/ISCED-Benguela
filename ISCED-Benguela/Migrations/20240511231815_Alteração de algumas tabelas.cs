using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçãodealgumastabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArquivoCursoID",
                table: "Cursos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Cursos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ArquivoCursoID",
                table: "Cursos",
                column: "ArquivoCursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Arquivos_ArquivoCursoID",
                table: "Cursos",
                column: "ArquivoCursoID",
                principalTable: "Arquivos",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Arquivos_ArquivoCursoID",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_ArquivoCursoID",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "ArquivoCursoID",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Cursos");
        }
    }
}
