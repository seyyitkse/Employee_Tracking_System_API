using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TrackingProject.WebApi.Dtos.AuthorizeDto;

namespace TrackingProject.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        [HttpPost("authorize")]
        public IActionResult AuthorizeToken([FromBody] TokenRequestModel model)
        {
            // Token doğrulama işlemi
            if (string.IsNullOrEmpty(model.Token))
            {
                return Unauthorized(); // Token boş ise yetkilendirme reddedilir
            }

            try
            {
                var jwtKey = "This is the key use in encryption"; // Örnek bir JWT key, gerçek bir uygulamada bu key güvenli bir şekilde saklanmalıdır
                // Token'ı doğrula
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(jwtKey); // JWT token için kullanılan gizli anahtar
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(model.Token, tokenValidationParameters, out validatedToken);

                // Token doğrulandıysa, yetkilendirme başarılıdır
                return Ok(new { authorized = true });
            }
            catch
            {
                // Token doğrulanamazsa, yetkilendirme reddedilir
                return Unauthorized();
            }
        }
    }
}
