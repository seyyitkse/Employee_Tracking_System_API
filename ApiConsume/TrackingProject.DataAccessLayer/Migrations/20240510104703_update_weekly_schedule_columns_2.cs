using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class update_weekly_schedule_columns_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedules_AspNetUsers_UserId1",
                table: "WeeklySchedules");

            migrationBuilder.DropIndex(
                name: "IX_WeeklySchedules_UserId1",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WeeklySchedules");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WeeklySchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "WeeklySchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_ApplicationUserId",
                table: "WeeklySchedules",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedules_AspNetUsers_ApplicationUserId",
                table: "WeeklySchedules",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeeklySchedules_AspNetUsers_ApplicationUserId",
                table: "WeeklySchedules");

            migrationBuilder.DropIndex(
                name: "IX_WeeklySchedules_ApplicationUserId",
                table: "WeeklySchedules");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WeeklySchedules");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WeeklySchedules",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "WeeklySchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_UserId1",
                table: "WeeklySchedules",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WeeklySchedules_AspNetUsers_UserId1",
                table: "WeeklySchedules",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
