using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbSample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixedSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Site_SiteId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Projects_ProjectId",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "Sites");

            migrationBuilder.RenameIndex(
                name: "IX_Site_ProjectId",
                table: "Sites",
                newName: "IX_Sites_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sites",
                table: "Sites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Sites_SiteId",
                table: "Participants",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Projects_ProjectId",
                table: "Sites",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Sites_SiteId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Projects_ProjectId",
                table: "Sites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sites",
                table: "Sites");

            migrationBuilder.RenameTable(
                name: "Sites",
                newName: "Site");

            migrationBuilder.RenameIndex(
                name: "IX_Sites_ProjectId",
                table: "Site",
                newName: "IX_Site_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Site_SiteId",
                table: "Participants",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Projects_ProjectId",
                table: "Site",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
