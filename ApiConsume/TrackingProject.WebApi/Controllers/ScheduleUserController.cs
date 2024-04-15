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
    public class ScheduleUserController : ControllerBase
    {
        //IScheduleUserService _scheduleUserService;
        //[HttpGet]
        //public IActionResult ScheduleUserList(ScheduleUser ScheduleUser)
        //{
        //    _scheduleUserService.TInsert(ScheduleUser);
        //    return Ok();
        //}
        //[HttpPost]
        //public IActionResult AddScheduleUser(ScheduleUser ScheduleUser)
        //{
        //    _scheduleUserService.TInsert(ScheduleUser);
        //    return Ok();
        //}
        //[HttpDelete]
        //public IActionResult DeleteScheduleUser(int id)
        //{
        //    var values = _scheduleUserService.TGetById(id);
        //    _scheduleUserService.TDelete(values);
        //    return Ok();
        //}
        //[HttpPut]
        //public IActionResult UpdateScheduleUser(ScheduleUser ScheduleUser)
        //{
        //    _scheduleUserService.TUpdate(ScheduleUser);
        //    return Ok();
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetScheduleUser(int id)
        //{
        //    var values = _scheduleUserService.TGetById(id);
        //    return Ok(values);
        //}
    }
}
