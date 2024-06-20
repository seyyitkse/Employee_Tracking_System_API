using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class RecognitionNotification
    {
        [Key]
        public int RecognitionID { get; set; }
        public string? Name{ get; set; }
        public string? Message{ get; set; }
        public long Time { get; set; }
        public bool Entry { get; set; }
        public int UserId { get; set; }
    }
}
