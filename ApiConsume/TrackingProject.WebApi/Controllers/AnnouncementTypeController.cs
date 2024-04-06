using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementTypeTypeController : ControllerBase
    {
        //IAnnouncementTypeService _announcementTypeService;

        //public AnnouncementTypeTypeController(IAnnouncementTypeService announcementTypeService)
        //{
        //    _announcementTypeService = announcementTypeService;
        //}

        //[HttpGet]
        //public IActionResult AnnouncementTypeList(AnnouncementType AnnouncementType)
        //{
        //    _announcementTypeService.TInsert(AnnouncementType);
        //    return Ok();
        //}
        //[HttpPost]
        //public IActionResult AddAnnouncementType(AnnouncementType AnnouncementType)
        //{
        //    _announcementTypeService.TInsert(AnnouncementType);
        //    return Ok();
        //}
        //[HttpDelete]
        //public IActionResult DeleteAnnouncementType(int id)
        //{
        //    var values = _announcementTypeService.TGetById(id);
        //    _announcementTypeService.TDelete(values);
        //    return Ok();
        //}
        //[HttpPut]
        //public IActionResult UpdateAnnouncementType(AnnouncementType AnnouncementType)
        //{
        //    _announcementTypeService.TUpdate(AnnouncementType);
        //    return Ok();
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetAnnouncementType(int id)
        //{
        //    var values = _announcementTypeService.TGetById(id);
        //    return Ok(values);
        //}
    }
}
