using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class addingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociai_Professores_ProfessoresID",
                table: "RedeSociai");

            migrationBuilder.DropIndex(
                name: "IX_RedeSociai_ProfessoresID",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "ProfessoresID",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "Rede",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "RedeSociai");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "RedeSociai",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "RedeSociai",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "RedeSociai",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "RedeSociai",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RedesID",
                table: "Professores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_RedesID",
                table: "Professores",
                column: "RedesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_RedeSociai_RedesID",
                table: "Professores",
                column: "RedesID",
                principalTable: "RedeSociai",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_RedeSociai_RedesID",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_RedesID",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "RedeSociai");

            migrationBuilder.DropColumn(
                name: "RedesID",
                table: "Professores");

            migrationBuilder.AddColumn<int>(
                name: "ProfessoresID",
                table: "RedeSociai",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rede",
                table: "RedeSociai",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "RedeSociai",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociai_ProfessoresID",
                table: "RedeSociai",
                column: "ProfessoresID");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociai_Professores_ProfessoresID",
                table: "RedeSociai",
                column: "ProfessoresID",
                principalTable: "Professores",
                principalColumn: "ID");
        }
    }
}
