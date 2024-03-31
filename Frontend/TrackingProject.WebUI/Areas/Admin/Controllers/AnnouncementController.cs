using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text;
using TrackingProject.WebUI.Areas.Admin.Models.ValidationRules;
using TrackingProject.WebUI.Areas.Admin.Models.ViewModels.Announcement;

namespace TrackingProject.WebUI.Controllers.Announcement
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AnnouncementController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5144/api/Announcement");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AnnouncementViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        
    }
}
