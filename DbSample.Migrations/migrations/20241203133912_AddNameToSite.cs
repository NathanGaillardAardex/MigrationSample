﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbSample.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sites",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sites");
        }
    }
}
