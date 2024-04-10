using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser > _userManager;

        public AuthController(IEmployeeService employeeService, UserManager<IdentityUser> userManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
        }


        //[HttpPost("Register")]
        //public async Task<IActionResult> RegisterAsync([FromBody]CreateEmployeeDto model)
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        var result=await _employeeService.RegisterUserAsync(model);
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result);
        //        }
        //        return BadRequest(result);
        //    }
        //    return BadRequest("Some properties are not valid");
        //}
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateEmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    // Yeni kullanıcı başarıyla kaydedildiğinde varsayılan rol atanması
                    var user = await _userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        // Varsayılan rolü eklemek için rol adını kullanabilirsiniz
                        var roleName = "Employee";

                        // Kullanıcıya rolü atama
                        var roleResult = await _userManager.AddToRoleAsync(user, roleName);
                        if (!roleResult.Succeeded)
                        {
                            // Rol atama başarısız ise uygun bir işlem yapılabilir
                            return BadRequest("Failed to assign default role to the user.");
                        }
                    }
                    else
                    {
                        // Kullanıcı bulunamazsa uygun bir işlem yapılabilir
                        return BadRequest("User not found after registration.");
                    }

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

