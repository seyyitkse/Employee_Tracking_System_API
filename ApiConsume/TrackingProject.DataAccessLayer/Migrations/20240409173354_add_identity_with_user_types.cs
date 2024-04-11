using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class add_identity_with_user_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "EmployeeUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "EmployeeUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "EmployeeUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "EmployeeUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "EmployeeUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "EmployeeUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "EmployeeUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AdminUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AdminUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AdminUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AdminUsers",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AdminUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AdminUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AdminUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "EmployeeUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AdminUsers");
        }
    }
}
