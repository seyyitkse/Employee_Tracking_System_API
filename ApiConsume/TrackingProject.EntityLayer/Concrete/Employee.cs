using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.EntityLayer.Concrete
{
    public class Employee:IdentityUser
    {
        public int DepartmentID { get; set; }
    }
}
