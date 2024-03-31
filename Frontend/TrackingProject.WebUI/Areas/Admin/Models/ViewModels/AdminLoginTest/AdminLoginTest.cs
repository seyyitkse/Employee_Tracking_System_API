using System.ComponentModel.DataAnnotations;

namespace TrackingProject.WebUI.Areas.Admin.Models.ViewModels.AdminLoginTest
{
    public class AdminLoginTest
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}
