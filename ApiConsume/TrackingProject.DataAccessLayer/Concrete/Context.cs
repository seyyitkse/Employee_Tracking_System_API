using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementType> AnnouncementTypes{ get; set; }
        public DbSet<ScheduleType> ScheduleTypes{ get; set; }
        public DbSet<WeeklySchedule> WeeklySchedules{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<RecognitionNotification> RecognitionNotifications{ get; set; }
        public DbSet<RFIDExample> RFIDExamples{ get; set; }
        public DbSet<UserProfileImage> UserImages{ get; set; }
        public Context(DbContextOptions<Context> options)
          : base(options) { }
    }
}
