﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        [HttpGet]
        public IActionResult AnnouncementList()
        {
            var values=_announcementService.TGetList();
            return Ok(values);
        }  
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement Announcement)
        {
            _announcementService.TInsert(Announcement);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            _announcementService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAnnouncement(Announcement Announcement)
        {
            _announcementService.TUpdate(Announcement);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAnnouncement(int id)
        {
            var values = _announcementService.TGetById(id);
            return Ok(values);
        }
    }
}
