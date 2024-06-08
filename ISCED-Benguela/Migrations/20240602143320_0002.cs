using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class _0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Estudantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AvatarID",
                table: "Estudantes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudantes_AvatarID",
                table: "Estudantes",
                column: "AvatarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudantes_Capas_AvatarID",
                table: "Estudantes",
                column: "AvatarID",
                principalTable: "Capas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudantes_Capas_AvatarID",
                table: "Estudantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudantes_AvatarID",
                table: "Estudantes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Estudantes");

            migrationBuilder.DropColumn(
                name: "AvatarID",
                table: "Estudantes");
        }
    }
}
