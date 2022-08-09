using Microsoft.AspNetCore.Authorization;
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
    public class SearchProductsController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        Services_ services_ = new Services_();


        // search product by id
        [HttpGet]
        [Route("api/searchproductbyid/{id}")]
        [Authorize(Roles ="admin,customer")]
        
        public IActionResult searchproductbyid(int id)
        {
            try
            {
                
                if (services_.getproductbyid(id) != null)
                {
                    return Ok(services_.getproductbyid(id));
                }
                else
                {
                    return NotFound($"Product with {id} is not found");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }    
        }

        //searchproduct by name

        [HttpGet]
        [Route("api/searchproductbyname/{productname}")]
       // [Authorize]
        public IActionResult searchproductbyname(string productname)
        {
            try
            {
                var _product = _context.Products.Where(x => x.ProductName.ToLower().Contains(productname.ToLower()));
                if (_product != null )
                {
                    return Ok(_product);
                }
                else
                {
                    return NotFound($" {productname} is not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
