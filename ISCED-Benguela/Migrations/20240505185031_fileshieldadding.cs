using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class fileshieldadding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caminho",
                table: "Capas",
                newName: "Extensoo");

            migrationBuilder.RenameColumn(
                name: "Caminho",
                table: "Arquivos",
                newName: "Extensao");

            migrationBuilder.AddColumn<byte[]>(
                name: "Ficheiro",
                table: "Capas",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Ficheiro",
                table: "Arquivos",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ficheiro",
                table: "Capas");

            migrationBuilder.DropColumn(
                name: "Ficheiro",
                table: "Arquivos");

            migrationBuilder.RenameColumn(
                name: "Extensoo",
                table: "Capas",
                newName: "Caminho");

            migrationBuilder.RenameColumn(
                name: "Extensao",
                table: "Arquivos",
                newName: "Caminho");
        }
    }
}
