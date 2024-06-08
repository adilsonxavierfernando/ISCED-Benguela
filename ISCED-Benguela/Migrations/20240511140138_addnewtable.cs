using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class addnewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefeDepartamentoID",
                table: "Departamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CapaCursoID",
                table: "Cursos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFuncionario = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    FotoID = table.Column<int>(type: "INTEGER", nullable: false),
                    RedesSociaisID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Capas_FotoID",
                        column: x => x.FotoID,
                        principalTable: "Capas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_RedeSociais_RedesSociaisID",
                        column: x => x.RedesSociaisID,
                        principalTable: "RedeSociais",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_ChefeDepartamentoID",
                table: "Departamentos",
                column: "ChefeDepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CapaCursoID",
                table: "Cursos",
                column: "CapaCursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FotoID",
                table: "Funcionarios",
                column: "FotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_RedesSociaisID",
                table: "Funcionarios",
                column: "RedesSociaisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Capas_CapaCursoID",
                table: "Cursos",
                column: "CapaCursoID",
                principalTable: "Capas",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefeDepartamentoID",
                table: "Departamentos",
                column: "ChefeDepartamentoID",
                principalTable: "Funcionarios",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Capas_CapaCursoID",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefeDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_ChefeDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_CapaCursoID",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "ChefeDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "CapaCursoID",
                table: "Cursos");
        }
    }
}
