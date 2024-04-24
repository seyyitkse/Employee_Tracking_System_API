using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class WeeklySchedule
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string? DayOfWeek { get; set; }

        [Required]
        public bool Working { get; set; }

        [Required]
        public bool Overtime { get; set; }

        [Required]
        public bool Vacation { get; set; }

        [Required]
        public bool Other { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
