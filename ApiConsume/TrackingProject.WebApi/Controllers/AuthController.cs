using Microsoft.AspNetCore.Http;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IEmployeeService _employeeService;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        public AuthController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(CreateEmployeeDto model)
        {
            if (ModelState.IsValid) 
            {
                var result=await _employeeService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }
<<<<<<< Updated upstream
    }
}
=======
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginEmployeeDto model)
        {
            var response = await _employeeService.LoginUserAsync(model);

            if (response.IsSuccess)
            {
                return Ok(new { message = response.Message });
            }
            else
            {
                return BadRequest(new { message = response.Message });
            }
        }
    }
}
 
>>>>>>> Stashed changes
