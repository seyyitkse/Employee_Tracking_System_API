using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.EntityLayer.Concrete
{
    public class ScheduleUser
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int Status { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public int ScheduleType { get; set; }
        public ScheduleType SchuduleType { get; set; }
    }
}
