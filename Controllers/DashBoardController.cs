using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using MockShoppingPriceComparisonApp2._0.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
    
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        Services_ _services = new Services_();


        [HttpGet]
        [Route("api/top5products")]

        public IActionResult top5products()
        {
            try
            { List<int> top5Ids = new List<int>();
                top5Ids = _services.top5Products();


                return Ok(top5Ids);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

        }
    }
}
