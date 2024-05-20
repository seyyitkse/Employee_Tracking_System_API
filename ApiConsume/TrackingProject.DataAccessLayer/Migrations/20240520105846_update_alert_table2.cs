using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_alert_table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "RecognitionNotifications",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Alerts",
                newName: "Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "RecognitionNotifications",
                newName: "Timestamp");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Alerts",
                newName: "Timestamp");
        }
    }
}
