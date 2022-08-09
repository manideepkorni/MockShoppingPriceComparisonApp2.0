using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using MockShoppingPriceComparisonApp2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{

    [ApiController]
    public class RegisterController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();

        public class customeruser
        {
            public string Username { get; set; }
            public string Givenname { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            //public string Role { get; set; }
        }
        public class adminuser
        {
            public string Username { get; set; }
            public string Givenname { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Accesscode { get; set; }
            //public string Role { get; set; }
        }
        Services_ services_ = new Services_();
        [Route("api/registerascustomer")]
        [AllowAnonymous]
        [HttpPost]


        public IActionResult Registerascustomer([FromBody] customeruser user)
        {
            try
            {
                if (!services_.CheckUsername(user.Username))
                {
                    Users _user = new Users()
                    {
                        UserName = user.Username,
                        UserGivenName = user.Givenname,
                        UserGender = user.Gender,
                        UserAge = user.Age,
                        UserEmail = user.Email,
                        UserPassword = services_.encryptPassword(user.Password),
                        UserAddress = user.Address,
                        UserRole = "customer"
                    };

                    _context.Users.Add(_user);
                    _context.SaveChanges();
                    return Created("usercreated", _context.Users.FirstOrDefault(x => x.UserName == _user.UserName));
                }
                else
                {
                    return Conflict("User Name Exists");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }
        [Route("api/registerasadmin")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Registerasadmin([FromBody] adminuser user)
        {
            try
            { if (user.Accesscode.ToLower() == "mockshoppingappadmin")
                {

                    if (!services_.CheckUsername(user.Username))
                    {
                        var _user = new Users()
                        {
                            UserName = user.Username,
                            UserGivenName = user.Givenname,
                            UserGender = user.Gender,
                            UserAge = user.Age,
                            UserEmail = user.Email,
                            UserPassword = services_.encryptPassword(user.Password),
                            UserAddress = user.Address,
                            UserRole = "admin"
                        };

                        _context.Users.Add(_user);
                        _context.SaveChanges();
                        var _user_ = _context.Users.FirstOrDefault(x => x.UserName == _user.UserName);
                        return Created("usercreated", new { _user_ });
                    }
                    else
                    {
                        return Conflict("User Name exists");
                    }
                }
                else
                {
                    return Conflict("Access code not valid. Try with correct access code");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        [Route("api/currentuser")]
        [HttpGet]
        public IActionResult currentuser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userclaims = identity.Claims;
                return Ok(new Users
                {
                    UserName = userclaims.FirstOrDefault(o => o.Type == "UserName")?.Value,
                    UserEmail = userclaims.FirstOrDefault(o => o.Type == "Email")?.Value,
                    UserGivenName = userclaims.FirstOrDefault(o => o.Type == "Givenname")?.Value,
                    UserRole = userclaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    UserId = (int)Convert.ToInt32(userclaims.FirstOrDefault(o => o.Type == "UserId")?.Value)
                });
            }
            else
                return NotFound("User not found");


        }

        [Route("api/encryptpassword")]
        [HttpGet]
        public IActionResult encrypt([FromBody] string password)
        {
              string key = "psiogdigital";
       
            if (string.IsNullOrEmpty(password)) return BadRequest();
          password += key;
              var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Ok(Convert.ToBase64String(passwordBytes));
    }
        



    }


    
}
