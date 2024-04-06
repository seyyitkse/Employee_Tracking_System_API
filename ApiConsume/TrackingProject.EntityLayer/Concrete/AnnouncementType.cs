using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//yetki seviyesi

namespace TrackingProject.EntityLayer.Concrete
{
    public class AnnouncementType
    {
        [Key]
        public int TypeID { get; set; }
        public string? Name { get; set; }
        public ICollection<Announcement> announcements { get; set; }
    }
}
