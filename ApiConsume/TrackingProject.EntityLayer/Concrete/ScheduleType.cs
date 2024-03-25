using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.EntityLayer.Concrete
{
    public class ScheduleType
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
    }
}
