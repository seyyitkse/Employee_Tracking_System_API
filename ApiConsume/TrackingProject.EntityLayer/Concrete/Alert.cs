using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public long Time{ get; set; }
        public int UserId { get; set; }
    }
}
