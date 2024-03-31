using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  TrackingProject.WebUI.Dtos.AnnouncementDto

{
    public class CreateAnnouncementDto
    {
        [Required(ErrorMessage ="Lütfen duyuru başlığını giriniz!")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lütfen içeriği yazınız!")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "Lütfen tarihi seçiniz!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Lütfen tip seçiniz!")]
        public int TypeID { get; set; }
    }
}
