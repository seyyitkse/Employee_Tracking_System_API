using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class RecognitionNotification
    {
        [Key]
        public int RecognitionID { get; set; }
        public string? Username{ get; set; }
        public string? Message{ get; set; }
        public DateTime Time { get; set; }
    }
}
