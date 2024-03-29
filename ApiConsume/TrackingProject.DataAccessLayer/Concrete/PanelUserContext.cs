using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.DataAccessLayer.Concrete
{
    public class PanelUserDbContext : IdentityDbContext<PanelUser, PanelUserRoles, int>
    {
        public PanelUserDbContext(DbContextOptions<PanelUserDbContext> options)
        : base(options)
        {
        }
    }
}
