using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();


        [HttpGet]
        [Route("api/getspecifications/{id}")]
        public IActionResult GetSpecifications(int id)
        {
            var _specifications = (from a in _context.SpecificationsCategoryRelation
                                   join b in _context.Specifications on a.SpecificationId equals b.SpecificationId
                                   where a.CategoryId == id
                                   select new
                                   {
                                       specificationName = b.SpecificationName
                                        
                                   }
                                   ).ToArray();
            if (_specifications != null)
                return Ok(_specifications);
            else
                return null;
        
        
        }


    }
}
