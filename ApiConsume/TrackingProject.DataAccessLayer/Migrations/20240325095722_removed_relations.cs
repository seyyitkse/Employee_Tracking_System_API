using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class removed_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AnnouncementTypes_AnnouncementTypeTypeID",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleUsers_ScheduleTypes_SchuduleTypeID",
                table: "ScheduleUsers");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleUsers_SchuduleTypeID",
                table: "ScheduleUsers");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_AnnouncementTypeTypeID",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "SchuduleTypeID",
                table: "ScheduleUsers",
                newName: "TypeID");

            migrationBuilder.RenameColumn(
                name: "AnnouncementTypeTypeID",
                table: "Announcements",
                newName: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "ScheduleUsers",
                newName: "SchuduleTypeID");

            migrationBuilder.RenameColumn(
                name: "TypeID",
                table: "Announcements",
                newName: "AnnouncementTypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleUsers_SchuduleTypeID",
                table: "ScheduleUsers",
                column: "SchuduleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AnnouncementTypeTypeID",
                table: "Announcements",
                column: "AnnouncementTypeTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AnnouncementTypes_AnnouncementTypeTypeID",
                table: "Announcements",
                column: "AnnouncementTypeTypeID",
                principalTable: "AnnouncementTypes",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleUsers_ScheduleTypes_SchuduleTypeID",
                table: "ScheduleUsers",
                column: "SchuduleTypeID",
                principalTable: "ScheduleTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
