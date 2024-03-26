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
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AddAnnouncementViewModel newAnnouncement)
        {
            AddAnnouncementValidator validations = new();
            ValidationResult results=validations.Validate(newAnnouncement);
            if (results.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(newAnnouncement);
                StringContent jsonAnnouncement = new(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5144/api/Announcement", jsonAnnouncement);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Announcement");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Route("announcementDetails")]
        [HttpGet("{id}")]
        public async Task<IActionResult> AnnouncementDetails(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5144/api/Announcement/{id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AnnouncementViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
