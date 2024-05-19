using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserService _applicationUserService;

        public EmployeeController(UserManager<ApplicationUser> userManager, IApplicationUserService applicationUserService)
        {
            _userManager = userManager;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Employee");
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var values = _applicationUserService.TGetById(id);
            return Ok(values);
        }
    }
}
