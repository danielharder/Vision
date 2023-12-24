using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vision.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Boards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Boards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Boards",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Boards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Boards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Boards");
        }
    }
}
