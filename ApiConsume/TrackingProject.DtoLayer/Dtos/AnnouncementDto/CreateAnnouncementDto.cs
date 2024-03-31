using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.DtoLayer.Dtos.AnnouncementDto
{
    public class CreateAnnouncementDto
    {
        [Required(ErrorMessage = "Lütfen duyuru başlığını giriniz!")]
        [MinLength(5, ErrorMessage = "Başlık en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Başlık en fazla 50 karakter olabilir.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen içeriği yazınız!")]
        [MinLength(10, ErrorMessage = "İçerik en az 10 karakter olmalıdır.")]
        [MaxLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Lütfen tarihi seçiniz!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Lütfen tip seçiniz!")]
        public int TypeID { get; set; }
    }
}
