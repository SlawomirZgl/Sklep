using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSklepu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            /*     if(user == null)
                 {
                     return BadRequest("Invalid client request");
                 }
                 if(user.Login == "login" && user.Password == "password")
                 {
                     var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                     var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                     var tokenOptions = new JwtSecurityToken(
                         issuer: "http://localhost:4200",
                         audience: "http://localhost:4200",
                         claims: new List<Claim>(),
                         expires: DateTime.Now.AddMinutes(5),
                         signingCredentials: signingCredentials
                         );
                     var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                     return Ok(new { Token = tokenString });
                 }
                 else
                 {
                     return Unauthorized();
                 }*/
            return Ok();
        }
    }
}
