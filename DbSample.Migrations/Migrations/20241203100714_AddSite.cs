using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbSample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Participants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_SiteId",
                table: "Participants",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_ProjectId",
                table: "Site",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Site_SiteId",
                table: "Participants",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Site_SiteId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropIndex(
                name: "IX_Participants_SiteId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Participants");
        }
    }
}
