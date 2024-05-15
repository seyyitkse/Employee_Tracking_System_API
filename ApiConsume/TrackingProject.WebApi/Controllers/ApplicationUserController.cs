using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetApplicationUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpGet("Employee/{departmentId}")]
        public async Task<IActionResult> GetStudentUsersByDepartment(int departmentId)
        {
            var studentUsers = await _userManager.GetUsersInRoleAsync("Employee");
            var studentUsersInDepartment = studentUsers.Where(u => u.DepartmentID == departmentId).ToList();

            return Ok(studentUsersInDepartment);
        }
        [HttpGet("Admin/{departmentId}")]
        public async Task<IActionResult> GetTeacherUsersByDepartment(int departmentId)
        {
            var teacherUsers = await _userManager.GetUsersInRoleAsync("Admin");
            var teacherUsersInDepartment = teacherUsers.Where(u => u.DepartmentID == departmentId).ToList();

            return Ok(teacherUsersInDepartment);
        }
    }
}
