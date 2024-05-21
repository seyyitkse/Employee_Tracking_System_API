using Microsoft.AspNetCore.Identity;

namespace TrackingProject.EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? FirstName{ get; set; }
        public string? LastName{ get; set; }
        public string? Fullname { get; set; }
        public int DepartmentID { get; set; }
        public virtual ICollection<WeeklySchedule> WeeklySchedules { get; set; }

    }
}
