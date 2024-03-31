using System.ComponentModel.DataAnnotations;

namespace TrackingProject.WebUI.Dtos.DeparmentDto
{
    public class CreateUpdateUserDto
    {
        [Required(ErrorMessage = "Lütfen departman ismini giriniz!!!")]
        [StringLength(100)]
        [MaxLength(100, ErrorMessage = "En fazla 100 karakter girilebilir!!!")]
        [MinLength(10, ErrorMessage = "En az 20 karakter olmalıdır.")]
        public string? Name { get; set; }
    }
}
