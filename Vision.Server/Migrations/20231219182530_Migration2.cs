using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vision.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "BoardMembers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BoardMembers");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardPK",
                table: "BoardMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserPK",
                table: "BoardMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardPK",
                table: "BoardMembers");

            migrationBuilder.DropColumn(
                name: "UserPK",
                table: "BoardMembers");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "BoardMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BoardMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
