using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        IAlertService _alertService;

        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }
        [HttpGet]
        public IActionResult AlertList()
        {
            var values = _alertService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAlert(Alert alert)
        {
            _alertService.TInsert(alert);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAlert(int id)
        {
            var values = _alertService.TGetById(id);
            _alertService.TDelete(values);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAlert(int id)
        {
            var values = _alertService.GetAlertsByUserId(id);
            return Ok(values);
        }
        [HttpGet("getAlerts/{userId}")]
        public IActionResult GetAlertsByUserId(int userId)
        {
            var values = _alertService.GetAlertsByUserId(userId);
            return Ok(values);
        }
    }
}
