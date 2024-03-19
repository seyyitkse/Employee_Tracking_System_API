using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementType> AnnouncementTypes{ get; set; }
        public DbSet<ScheduleType> ScheduleTypes{ get; set; }
        public DbSet<ScheduleUser> ScheduleUsers{ get; set; }
        public DbSet<Department> Departments{ get; set; }

        public Context(DbContextOptions<Context> options)
          : base(options) { }
    }
}
