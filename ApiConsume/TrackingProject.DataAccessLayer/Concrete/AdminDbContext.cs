using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.Concrete
{
    public class AdminDbContext:IdentityDbContext<Admin,IdentityRole,string>
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
        : base(options)
        {
        }
    }
}
