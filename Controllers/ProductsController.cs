using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using MockShoppingPriceComparisonApp2._0.Services;
using System;
using System.Linq;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{

    [ApiController]
    public class ProductsController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        Services_ _services = new Services_();
        //get all the products
        [HttpGet]
        [Authorize(Roles ="admin")]
        [Route("api/getallproducts")]

        public IActionResult getallproducts()
        {
           try
            {
                var _products = _context.Products.ToList();

                if (_products != null)
                    return Ok(_products.Where(x => x.Isdeleted == false ));
                else
                    return NotFound("no products are found");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }  
        
        [HttpGet]
        //[Authorize]
        [Route("api/getproductsbycategory/{id}")]

        public IActionResult getproductsbycategory(int id)
        {
           try
            {
               var _products =  _context.Products.Where(x => x.CategoryId == id &&  x.Isdeleted == false);

                if (_products != null)

                {
                   


                    return Ok(_products);
                }
                else
                    return NotFound("no products are found");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/getproductbyid/{id}")]

        public IActionResult getproductbyid(int id)
        {
            return Ok(_services.GetProductswithSpecifications(id));
        }



        [HttpPatch]
        [Authorize(Roles = "admin")]
        [Route("api/updateproductdetails/{id}")]
      
        public IActionResult updateproduct([FromBody] JsonPatchDocument Productsmodel, int id)

        {
            try
            {
                var _product = _context.Products.Find(id);
                if (_product != null)
                {
                    Productsmodel.ApplyTo(_product);
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


        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("api/addproduct")]
        public IActionResult addProduct([FromBody] Products product)
        {
            try
            { var _product = _context.Products.FirstOrDefault(x => x.ProductName == product.ProductName);
                if(_product != null)
                {
                    return Conflict("Product is already there");
                }
             else
                {

                _context.Products.Add(product);
                _context.SaveChanges();
                return Created("created", _context.Products.FirstOrDefault(x => x.ProductName == product.ProductName));
                }
            }

            catch (Exception e)
            {

                return BadRequest(e.InnerException.Message);
            
            }
            
        
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("api/addspecifications")]
        public IActionResult addSpecification([FromBody] ProductSpecifications productSpec)
        {

            try
            {
                var _product = _context.ProductSpecifications.Where(x => x.ProductId == productSpec.ProductId).ToList();
                var _temp = _product.FirstOrDefault(x => x.SpecCatId == productSpec.SpecCatId);
                if (_temp != null)
                {
                    return Conflict("Specvalue already present. Please update if you want to change");
                }
                else
                {
                    _context.ProductSpecifications.Add(productSpec);
                    _context.SaveChanges();
                    return Created("created", $"specfication added to productId : {productSpec.ProductId}  ");
                }


            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException.Message);

            }


        }



    }
}
