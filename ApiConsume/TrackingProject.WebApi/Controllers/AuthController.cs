using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Security.Claims;
using TrackingProject.BusinessLayer.Abstract;
using TrackingProject.DtoLayer.Dtos.EmployeeDto;
using TrackingProject.WebApi.Jwt;

namespace TrackingProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public AuthController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]CreateEmployeeDto model)
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
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(new {Token=result.Message});
                }
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");
        }
    }
}

