using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class Deleiçõesebloqueios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Professores",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bloqueado",
                table: "Estudantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Bloqueado",
                table: "Estudantes");
        }
    }
}
