using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.EntityLayer.Concrete
{
    public class PanelUser:IdentityUser<int>
    {
        [Key]
        public int PanelUserID{ get; set; }
        public int DepartmentID{ get; set; }
    }
}
