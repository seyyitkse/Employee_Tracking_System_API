using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_weekly_schedule_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Vacation",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Working",
                table: "WeeklySchedules");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "WeeklySchedules",
                newName: "ScheduleID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WeeklySchedules",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Endtime",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Starttime",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Workdate",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Endtime",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Starttime",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "Workdate",
                table: "WeeklySchedules");

            migrationBuilder.RenameColumn(
                name: "ScheduleID",
                table: "WeeklySchedules",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "WeeklySchedules",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Other",
                table: "WeeklySchedules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Overtime",
                table: "WeeklySchedules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vacation",
                table: "WeeklySchedules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Working",
                table: "WeeklySchedules",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
