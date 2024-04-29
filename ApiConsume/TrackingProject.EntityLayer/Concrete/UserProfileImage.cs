using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrackingProject.EntityLayer.Concrete
{
    public class UserProfileImage
    {
        [Key]
        public int ImageID { get; set; }

        public int EmployeeID{ get; set; }

        public byte[]? ImageData { get; set; }

        public string? ImageMimeType { get; set; }
        public int? deneme { get; set; }

        [NotMapped]
        public bool IsSizeValid => ImageData?.Length <= 2 * 1024 * 1024; 
    }
}

