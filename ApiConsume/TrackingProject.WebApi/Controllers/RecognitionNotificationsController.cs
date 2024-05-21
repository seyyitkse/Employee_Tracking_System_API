using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DataAccessLayer.Concrete;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionNotificationsController : ControllerBase
    {
        IRecognitionNotificationService _recognitionNotificationService;
        private readonly Context _context;
        private readonly IAlertService _alertService;
        public RecognitionNotificationsController(IRecognitionNotificationService recognitionNotificationService, Context context, IAlertService alertService)
        {
            _recognitionNotificationService = recognitionNotificationService;
            _context = context;
            _alertService = alertService;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _recognitionNotificationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddNotification([FromBody] RecognitionNotification notification)
        {
            if (notification == null)
            {
                return BadRequest("Notification is required.");
            }

            // Attempt to find the user by their first name
            var user = _context.Users.FirstOrDefault(x => x.Fullname == notification.Name);
            if (user == null)
            {
                return NotFound("User not found");
            }

            notification.Time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            // Assign user information to the notification
            notification.Message = "Kullanıcı giriş yaptı.";
            notification.UserId = user.Id;

            // Convert the Unix timestamp to DateTime
            DateTime dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)notification.Time)
                                            .ToOffset(TimeSpan.FromHours(3))
                                            .DateTime;
            // Define working hours
            TimeSpan start = new TimeSpan(8, 0, 0); // 8:00 AM
            TimeSpan end = new TimeSpan(17, 0, 0); // 5:00 PM
            TimeSpan now = dateTime.TimeOfDay;

            // Create the alert object
            var alert = new Alert
            {
                Time = notification.Time,
                UserId = notification.UserId
            };

            if (now >= start && now <= end)
            {
                alert.Message = "Kullanıcı mesai saatlerinde giriş yaptı.";
                alert.Type = "success";
            }
            else
            {
                alert.Message = "Kullanıcı mesai saatleri dışında giriş yaptı.";
                alert.Type = "warning";
            }

            // Insert the alert using the alert service
            _alertService.TInsert(alert);

            // Insert the notification using the notification service
            _recognitionNotificationService.TInsert(notification);

            return Ok("Giriş başarılı!");
        }

        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var values = _recognitionNotificationService.TGetById(id);
            _recognitionNotificationService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateNotification(RecognitionNotification notification)
        {
            _recognitionNotificationService.TUpdate(notification);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var values = _recognitionNotificationService.TGetById(id);
            return Ok(values);
        }
    }
}
