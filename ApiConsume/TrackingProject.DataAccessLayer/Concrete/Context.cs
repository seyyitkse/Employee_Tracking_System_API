﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<ApplicationUser,ApplicationRole,string>
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
