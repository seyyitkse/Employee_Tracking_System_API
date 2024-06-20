using Microsoft.AspNetCore.Authorization;
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
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult DepartmentList()
        {
            var values = _departmentService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddDepartment(Department Department)
        {
            _departmentService.TInsert(Department);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var values = _departmentService.TGetById(id);
            _departmentService.TDelete(values);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> CloseDepartment(int id)
        {
            // Find the department with the given ID
            var department = _departmentService.TGetById(id);
            if (department == null)
            {
                return NotFound("Departman kapatma hatası!");
            }

            // Update the department status
            department.Status = false;
            _departmentService.TUpdate(department);
            return Ok("Departman kapatma işlemi başarıyla gerçekleşti.");
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var values = _departmentService.TGetById(id);
            return Ok(values);
        }
    }
}
