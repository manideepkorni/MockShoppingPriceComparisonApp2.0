using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MockShoppingPriceComparisonApp2._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        [Authorize(Roles ="admin")]
        [Route("api/deleteuser/{id}")]
        [HttpDelete]
        public IActionResult deleteuser(int id)
        {
            try
            {
                var _user = _context.Users.Find(id);
                if (_user != null)
                {
                    _context.Users.Remove(_user);
                    _context.SaveChanges();
                    return Ok("record deletd");
                }
                else
                    return NotFound("User not found");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Authorize(Roles = "admin")]
        [Route("api/updateuserdetails/{id}")]

        public IActionResult updateuser([FromBody] JsonPatchDocument userModel, int id)

        {
            try
            {
                var _user = _context.Users.Find(id);
                if (_user != null)
                {
                    userModel.ApplyTo(_user);
                    _context.SaveChanges();
                    return Ok("record updated");

                }
                else
                    return NotFound("productnot found");
            }

            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }





        //[Route("api/checkusername")]
        //[HttpGet]
        //public IActionResult checkUsername([FromBody] string Username)
        //{ var _username = _context.Users.FirstOrDefault(x => x.UserName == Username).UserName.ToString();
        //    if (_username != null)
        //        return Ok(_username);
        //    else
        //        return null;
        //}





    }
}
