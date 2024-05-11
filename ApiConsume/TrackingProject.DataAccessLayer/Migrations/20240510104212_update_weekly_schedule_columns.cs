using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_weekly_schedule_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Workdate",
                table: "WeeklySchedules");

            migrationBuilder.AlterColumn<long>(
                name: "Starttime",
                table: "WeeklySchedules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<long>(
                name: "Endtime",
                table: "WeeklySchedules",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Starttime",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Endtime",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "Workdate",
                table: "WeeklySchedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
