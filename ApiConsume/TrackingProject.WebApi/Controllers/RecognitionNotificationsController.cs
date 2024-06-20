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

            // Check if the name is "Unknown"
            if (notification.Name.Equals("Unknown", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Bilinmeyen kullanıcı!!!");
            }
            // Attempt to find the user by their full name
            var user = _context.Users.FirstOrDefault(x => x.Fullname == notification.Name);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            notification.Time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            notification.UserId = user.Id;

            // Check the last notification for the user
            var lastNotification = _context.RecognitionNotifications
                .Where(r => r.UserId == user.Id)
                .OrderByDescending(r => r.RecognitionID)
                .FirstOrDefault();

            // Prevent duplicate entry or exit
            if (lastNotification != null)
            {
                if (notification.Entry == lastNotification.Entry)
                {
                    if (notification.Entry)
                    {
                        return BadRequest("Kullanıcı zaten giriş yaptı!");
                    }
                    else
                    {
                        return BadRequest("Kullanıcı zaten çıkış yaptı!");
                    }
                }
            }

            // Assign message based on entry or exit
            if (notification.Entry==true)
            {
                notification.Message = "Kullanıcı giriş yaptı.";
            }
            else
            {
                notification.Message = "Kullanıcı çıkış yaptı.";
            }

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

            if (now >= start && now <= end && notification.Entry)
            {
                alert.Message = "Kullanıcı mesai saatlerinde giriş yaptı.";
                alert.Type = "success";
                alert.Entry = true;
            }
            else if (now >= start && now <= end && !notification.Entry)
            {
                alert.Message = "Kullanıcı mesai saatlerinde çıkış yaptı.";
                alert.Type = "success";
                alert.Entry = false;
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

            // Add to schedule user table as an event between entry-exit transaction
            if (lastNotification != null && !notification.Entry)
            {
                var userSchedule = new WeeklySchedule
                {
                    UserId = notification.UserId,
                    Starttime = lastNotification.Time,
                    Endtime = notification.Time,
                    Description = "Çalışma Saatleri- Giriş-Çıkış"
                };

                _context.WeeklySchedules.Add(userSchedule);
                _context.SaveChanges();
            }

            return Ok(notification.Entry ? "Giriş başarılı!" : "Çıkış başarılı");
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
