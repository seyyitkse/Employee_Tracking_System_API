using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public int DepartmentID { get; set; }
    }
}
