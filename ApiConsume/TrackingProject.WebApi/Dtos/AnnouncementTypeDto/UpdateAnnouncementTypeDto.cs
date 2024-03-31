using System.ComponentModel.DataAnnotations;

namespace TrackingProject.WebApi.Dtos.ServiceDto
{
    public class UpdateAnnouncementTypeDto
    {
        public int TypeID { get; set; }
        [Required(ErrorMessage = "Lütfen duyuru tipinin ismini giriniz!!!")]
        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir!!!")]
        [MinLength(10, ErrorMessage = "En az 20 karakter olmalıdır.")]
        public string? Name { get; set; }
    }
}
