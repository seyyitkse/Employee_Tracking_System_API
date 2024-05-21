using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_alert_table3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Alerts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Alerts");
        }
    }
}
