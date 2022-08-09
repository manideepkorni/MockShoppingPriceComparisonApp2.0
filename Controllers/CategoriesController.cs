using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using MockShoppingPriceComparisonApp2._0.Services;
using System.Linq;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{

    [ApiController]
    public class CategoriesController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        Services_ services_ = new Services_();
        [HttpGet]
        [Route("api/getcategories")]
        [AllowAnonymous]
        public IActionResult getcategories()
        {
            var _categories = _context.Category.Select(p => new
            {
                p.CategoryId
             ,
                p.CategoryName
            }).ToList();
            if (_categories != null)

                return Ok(_categories);
            else
                return NotFound("No categories found");
        }



        [HttpGet]
        [Route("api/getbrands")]
        [AllowAnonymous]
        public IActionResult getbrands()
        {

            var _brands = _context.Brands.Select(p => new
            {
                p.BrandId,
                p.BrandName
            }).ToList();
            if (_brands != null)

                return Ok(_brands);
            else
                return NotFound("No brnads found");
        }


    }
}
