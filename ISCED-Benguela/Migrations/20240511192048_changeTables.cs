using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCED_Benguela.Migrations
{
    /// <inheritdoc />
    public partial class changeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_InfoSites_InfoSiteID",
                table: "RedeSociais");

            migrationBuilder.DropIndex(
                name: "IX_RedeSociais_InfoSiteID",
                table: "RedeSociais");

            migrationBuilder.DropColumn(
                name: "InfoSiteID",
                table: "RedeSociais");

            migrationBuilder.AddColumn<int>(
                name: "RedesID",
                table: "InfoSites",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InfoSites_RedesID",
                table: "InfoSites",
                column: "RedesID");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSites_RedeSociais_RedesID",
                table: "InfoSites",
                column: "RedesID",
                principalTable: "RedeSociais",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSites_RedeSociais_RedesID",
                table: "InfoSites");

            migrationBuilder.DropIndex(
                name: "IX_InfoSites_RedesID",
                table: "InfoSites");

            migrationBuilder.DropColumn(
                name: "RedesID",
                table: "InfoSites");

            migrationBuilder.AddColumn<int>(
                name: "InfoSiteID",
                table: "RedeSociais",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_InfoSiteID",
                table: "RedeSociais",
                column: "InfoSiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_InfoSites_InfoSiteID",
                table: "RedeSociais",
                column: "InfoSiteID",
                principalTable: "InfoSites",
                principalColumn: "ID");
        }
    }
}
