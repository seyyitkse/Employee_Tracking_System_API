using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTypeController : ControllerBase
    {
        IScheduleTypeService _scheduleTypeService;

        public ScheduleTypeController(IScheduleTypeService scheduleTypeService)
        {
            _scheduleTypeService = scheduleTypeService;
        }

        [HttpGet]
        public IActionResult ScheduleTypeList(ScheduleType ScheduleType)
        {
            _scheduleTypeService.TInsert(ScheduleType);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddScheduleType(ScheduleType ScheduleType)
        {
            _scheduleTypeService.TInsert(ScheduleType);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteScheduleType(int id)
        {
            var values = _scheduleTypeService.TGetById(id);
            _scheduleTypeService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateScheduleType(ScheduleType ScheduleType)
        {
            _scheduleTypeService.TUpdate(ScheduleType);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetScheduleType(int id)
        {
            var values = _scheduleTypeService.TGetById(id);
            return Ok(values);
        }
    }
}
