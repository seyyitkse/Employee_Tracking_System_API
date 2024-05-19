using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class RecognitionNotification
    {
        [Key]
        public int RecognitionID { get; set; }
        public string? Name{ get; set; }
        public string? Message{ get; set; }
        public long DateTime { get; set; }
    }
}
