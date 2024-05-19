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
        IWeeklyScheduleService _scheduleUserService;

        public ScheduleUserController(IWeeklyScheduleService scheduleUserService)
        {
            _scheduleUserService = scheduleUserService;
        }

        [HttpGet]
        public IActionResult ScheduleUserList()
        {
            var values = _scheduleUserService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddScheduleUser(WeeklySchedule ScheduleUser)
        {
            _scheduleUserService.TInsert(ScheduleUser);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteScheduleUser(int id)
        {
            var values = _scheduleUserService.TGetById(id);
            _scheduleUserService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateScheduleUser(WeeklySchedule ScheduleUser)
        {
            _scheduleUserService.TUpdate(ScheduleUser);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSchedule(int id)
        {
            try
            {
                var schedule = await _scheduleUserService.GetScheduleByUserId(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("unixTimeCode")]
        public long GetCurrentUnixTimeStampMillis()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<WeeklySchedule>> GetEvents()
        //{
        //    try
        //    {
        //        var events = _scheduleUserService.TGetList();
        //        // UNIX zaman damgası olarak tarih bilgisini döndür
        //        return Ok(events.Select(e => new WeeklySchedule
        //        {
        //            ScheduleID = e.ScheduleID,
        //            Description = e.Description,
        //            Starttime =e.Starttime,
        //            Endtime = e.Endtime
        //        }));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}
    }
}
