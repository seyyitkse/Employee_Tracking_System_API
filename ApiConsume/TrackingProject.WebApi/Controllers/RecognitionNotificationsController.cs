using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionNotificationsController : ControllerBase
    {
        IRecognitionNotificationService _recognitionNotificationService;

        public RecognitionNotificationsController(IRecognitionNotificationService recognitionNotificationService)
        {
            _recognitionNotificationService = recognitionNotificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _recognitionNotificationService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddNotification(RecognitionNotification notification)
        {
            _recognitionNotificationService.TInsert(notification);
            return Ok();
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
