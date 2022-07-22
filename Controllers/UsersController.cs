using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockShoppingPriceComparisonApp2._0.Models;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();

        [Route("api/checkusername")]
        [HttpPost]
        public IActionResult checkUsername([FromBody] string Username)
        { var _username = _context.Users.FirstOrDefault(x => x.UserName == Username).UserName.ToString();
            if (_username != null)
                return Ok(_username);
            else
                return null;
        }
    }
}
