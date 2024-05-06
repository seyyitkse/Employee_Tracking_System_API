using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class RFIDExample
    {
        [Key]
        public int RFIDId { get; set; }
        public string? RFIDNo { get; set; }
        public string? RFIDName { get; set; }
    }
}
