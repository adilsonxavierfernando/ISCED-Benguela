using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class Inseridonovacolunaemcomentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefeDepartamentoID",
                table: "Departamentos");

            migrationBuilder.RenameColumn(
                name: "ChefeDepartamentoID",
                table: "Departamentos",
                newName: "ChefedepartamentoID");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_ChefeDepartamentoID",
                table: "Departamentos",
                newName: "IX_Departamentos_ChefedepartamentoID");

            migrationBuilder.AlterColumn<int>(
                name: "ChefedepartamentoID",
                table: "Departamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Respondido",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefedepartamentoID",
                table: "Departamentos",
                column: "ChefedepartamentoID",
                principalTable: "Funcionarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefedepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Respondido",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "ChefedepartamentoID",
                table: "Departamentos",
                newName: "ChefeDepartamentoID");

            migrationBuilder.RenameIndex(
                name: "IX_Departamentos_ChefedepartamentoID",
                table: "Departamentos",
                newName: "IX_Departamentos_ChefeDepartamentoID");

            migrationBuilder.AlterColumn<int>(
                name: "ChefeDepartamentoID",
                table: "Departamentos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Funcionarios_ChefeDepartamentoID",
                table: "Departamentos",
                column: "ChefeDepartamentoID",
                principalTable: "Funcionarios",
                principalColumn: "ID");
        }
    }
}
