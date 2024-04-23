using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingProject.DataAccessLayer.Migrations
{
    public partial class add_weekly_schedule_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ScheduleUsers");

            migrationBuilder.CreateTable(
                name: "WeeklySchedules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Working = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Overtime = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Vacation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Other = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklySchedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WeeklySchedules_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklySchedules_UserId",
                table: "WeeklySchedules",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeeklySchedules");

            //migrationBuilder.CreateTable(
            //    name: "ScheduleUsers",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(type: "varchar(255)", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        DayOfWeek = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Other = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //        Overtime = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //        Vacation = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //        Working = table.Column<bool>(type: "tinyint(1)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScheduleUsers", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_ScheduleUsers_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScheduleUsers_UserId",
            //    table: "ScheduleUsers",
            //    column: "UserId");
        }
    }
}
