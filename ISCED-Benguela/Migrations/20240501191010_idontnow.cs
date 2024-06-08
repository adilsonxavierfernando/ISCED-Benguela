using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class idontnow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Cursos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bilhetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Validade = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhetes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DepartamentoID",
                table: "Cursos",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Departamentos_DepartamentoID",
                table: "Cursos");

            migrationBuilder.DropTable(
                name: "Bilhetes");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_DepartamentoID",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Cursos");
        }
    }
}
