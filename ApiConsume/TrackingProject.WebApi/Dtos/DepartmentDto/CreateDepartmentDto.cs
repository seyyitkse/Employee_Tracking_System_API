using System.ComponentModel.DataAnnotations;

namespace TrackingProject.WebApi.Dtos.DepartmentDto
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Lütfen departman adını giriniz!")]
        [MinLength(5, ErrorMessage = "Departman adı en az 2 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Başlık en fazla 50 karakter olabilir.")]
        public string? Name { get; set; }
        public bool Status { get; set; }
        public CreateDepartmentDto()
        {
            Status = true;
        }
    }
}
