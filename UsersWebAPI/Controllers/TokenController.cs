using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using UsersWebAPI.Models;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace UsersWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] User user)
        {
            if (user.Name == "ruan.barros" && user.Password == "123456")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(issuer: "ruan.barros"
                                                , audience: "ruan.barros"
                                                , claims: claims
                                                , expires: DateTime.Now.AddMinutes(30)
                                                , signingCredentials: creds);

                return Ok(new 
                { 
                    token = new JwtSecurityTokenHandler().WriteToken(token) 
                });
            }

            return BadRequest("Credenciais inválidas");
        }
    }
}
