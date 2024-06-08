using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class addingTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_RedeSociai_RedesID",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociai_InfoSites_InfoSiteID",
                table: "RedeSociai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedeSociai",
                table: "RedeSociai");

            migrationBuilder.RenameTable(
                name: "RedeSociai",
                newName: "RedeSociais");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSociai_InfoSiteID",
                table: "RedeSociais",
                newName: "IX_RedeSociais_InfoSiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedeSociais",
                table: "RedeSociais",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_RedeSociais_RedesID",
                table: "Professores",
                column: "RedesID",
                principalTable: "RedeSociais",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_InfoSites_InfoSiteID",
                table: "RedeSociais",
                column: "InfoSiteID",
                principalTable: "InfoSites",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_RedeSociais_RedesID",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_InfoSites_InfoSiteID",
                table: "RedeSociais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedeSociais",
                table: "RedeSociais");

            migrationBuilder.RenameTable(
                name: "RedeSociais",
                newName: "RedeSociai");

            migrationBuilder.RenameIndex(
                name: "IX_RedeSociais_InfoSiteID",
                table: "RedeSociai",
                newName: "IX_RedeSociai_InfoSiteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedeSociai",
                table: "RedeSociai",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_RedeSociai_RedesID",
                table: "Professores",
                column: "RedesID",
                principalTable: "RedeSociai",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociai_InfoSites_InfoSiteID",
                table: "RedeSociai",
                column: "InfoSiteID",
                principalTable: "InfoSites",
                principalColumn: "ID");
        }
    }
}
