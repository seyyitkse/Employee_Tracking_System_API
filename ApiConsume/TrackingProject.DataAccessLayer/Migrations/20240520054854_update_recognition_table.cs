using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_recognition_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "RecognitionNotifications",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Alerts",
                newName: "Message");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RecognitionNotifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Alerts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RecognitionNotifications");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "RecognitionNotifications",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Alerts",
                newName: "Content");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Alerts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Alerts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
