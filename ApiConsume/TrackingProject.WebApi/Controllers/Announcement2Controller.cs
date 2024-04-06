using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.AnnouncementDto;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Announcement2Controller : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public Announcement2Controller(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values =  _announcementService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAnnouncement(CreateAnnouncementDto  announcementAddDto)
        {
            var values = _mapper.Map<Announcement>(announcementAddDto);
            _announcementService.TInsert(values);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementDto announcementUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Announcement>(announcementUpdateDto);
             _announcementService.TUpdate(values);
            return Ok("Güncelleme başarılı!");
        }
    }
}
