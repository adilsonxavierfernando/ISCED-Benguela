using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class InsertChieldFromComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaID",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_MateriaID",
                table: "Comentario",
                column: "MateriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Materias_MateriaID",
                table: "Comentario",
                column: "MateriaID",
                principalTable: "Materias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Materias_MateriaID",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_MateriaID",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "MateriaID",
                table: "Comentario");
        }
    }
}
