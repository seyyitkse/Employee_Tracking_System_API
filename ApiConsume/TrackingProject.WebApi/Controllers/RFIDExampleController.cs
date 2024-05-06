using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class RFIDExampleController : ControllerBase
    {
        IRFIDExampleService _RFIDexampleService;

        public RFIDExampleController(IRFIDExampleService exampleService)
        {
            _RFIDexampleService = exampleService;
        }

        [HttpGet]
        public IActionResult RFIDExampleList()
        {
            var values = _RFIDexampleService.TGetList();
            return Ok(values);
        }
        [HttpPost("addRFIDExample")]
        public IActionResult AddRFIDExample(RFIDExample RFIDExample)
        {
            _RFIDexampleService.TInsert(RFIDExample);
            return Ok("Ekleme islemi basarili!");
        }
        [HttpDelete]
        public IActionResult DeleteRFIDExample(int id)
        {
            var values = _RFIDexampleService.TGetById(id);
            _RFIDexampleService.TDelete(values);
            return Ok("Silme islemi basarili!");
        }
        [HttpPut]
        public IActionResult UpdateRFIDExample(RFIDExample RFIDExample)
        {
            _RFIDexampleService.TUpdate(RFIDExample);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRFIDExample(int id)
        {
            var values = _RFIDexampleService.TGetById(id);
            return Ok(values);
        }
    }
}
