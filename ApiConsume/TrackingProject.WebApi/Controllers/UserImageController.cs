using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrackingProject.BusinessLayer.Concrete;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        private readonly UserImageManager _userImageManager;

        public UserImageController(UserImageManager userImageManager)
        {
            _userImageManager = userImageManager;
        }



        // Diğer endpoint'ler...

        [HttpPost("{userId}/images")]
        public async Task<IActionResult> AddUserImage(int userId, [FromForm] IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Image file is required");
            }

            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();
                var imageMimeType = imageFile.ContentType;

                await _userImageManager.AddUserImageAsync(userId, imageData, imageMimeType);
            }

            return Ok("Image added successfully");
        }
    }
}

