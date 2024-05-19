using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class WeeklySchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public long Starttime { get; set; }
        public long Endtime { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
