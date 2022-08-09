using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockShoppingPriceComparisonApp2._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MockShoppingPriceComparisonApp2._0.Services;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
  
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();

        Services_ _services = new Services_();
        public LoginController(IConfiguration config)
        {
            _config = config;
           
        }

        public class UserLogin
        {
            public string usernameoremail { get; set; }
            public string password { get; set; }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var tokenString = Generate(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string Generate(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
       
            var claims = new[]
            {   new Claim("UserId",user.UserId.ToString()),
                new Claim("UserName",user.UserName),
                new Claim("Email",user.UserEmail),
                new Claim("Givenname",user.UserGivenName),
                 new Claim(ClaimTypes.Role,user.UserRole),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
               _config["Jwt:Audience"],
               claims,
               expires: DateTime.Now.AddMinutes(360),
               signingCredentials: credentials
               );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Users Authenticate(UserLogin userLogin)
        {
            var currentuser = _context.Users.FirstOrDefault(x => (x.UserName.ToLower() == userLogin.usernameoremail.ToLower() ) && x.UserPassword == _services.encryptPassword(userLogin.password));
            if (currentuser != null)
            {
                return currentuser;
            }
            return null;
        }
    }
}