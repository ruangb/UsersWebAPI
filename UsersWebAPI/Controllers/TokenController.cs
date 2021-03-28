using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UsersWebAPI.Models;

namespace UsersWebAPI.Controllers
{
    [Route("api/controller")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public IActionResult RequestToken([FromBody] User user)
        //{
        //    if (user.Name == "Ruan" && user.Password == "12345")
        //    {
        //        var claim = new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Name),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.Role, "Administrativo")
        //        };

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
        //    }
        //}
    }
}
