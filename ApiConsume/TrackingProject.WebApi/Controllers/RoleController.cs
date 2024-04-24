using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task< IActionResult> GetRoles()
        {
            var roles =await _roleManager.Roles.ToListAsync();
            return Ok(roles);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateRole(ApplicationRole roleModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Check if the role already exists
        //        bool roleExists = await _roleManager.RoleExistsAsync(roleModel?.RoleName);
        //        if (roleExists)
        //        {
        //            ModelState.AddModelError("", "Role Already Exists");
        //        }
        //        else
        //        {
        //            // Create the role
        //            // We just need to specify a unique role name to create a new role
        //            ApplicationRole identityRole = new ApplicationRole
        //            {
        //                Name = roleModel?.RoleName
        //            };
        //            // Saves the role in the underlying AspNetRoles table
        //            IdentityResult result = await _roleManager.CreateAsync(identityRole);
        //            if (result.Succeeded)
        //            {
        //                return Ok($"'{roleModel.RoleName}' adlı rol başarıyla oluşturuldu.");
        //            }         
        //            return BadRequest("Rol oluşturma başarısız."); 
        //        }
        //    }
        //    return Ok(" Hata!!!");
        //}
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                ModelState.AddModelError("", "Role name cannot be empty");
                return BadRequest(ModelState);
            }

            // Check if the role already exists
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                ModelState.AddModelError("", "Role already exists");
                return BadRequest(ModelState);
            }

            // Create the role
            ApplicationRole role = new ApplicationRole
            {
                Name=roleName,
            };

            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok($"Role '{roleName}' created successfully.");
            }

            // If role creation failed, return error message
            ModelState.AddModelError("", "Failed to create role");
            return BadRequest(ModelState);
        }

    }
}
