using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class changeShieldnameInCapa02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disicplina_Professores_ProfessoresID",
                table: "Disicplina");

            migrationBuilder.DropIndex(
                name: "IX_Disicplina_ProfessoresID",
                table: "Disicplina");

            migrationBuilder.DropColumn(
                name: "ProfessoresID",
                table: "Disicplina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessoresID",
                table: "Disicplina",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disicplina_ProfessoresID",
                table: "Disicplina",
                column: "ProfessoresID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disicplina_Professores_ProfessoresID",
                table: "Disicplina",
                column: "ProfessoresID",
                principalTable: "Professores",
                principalColumn: "ID");
        }
    }
}
