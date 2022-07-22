using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockShoppingPriceComparisonApp2._0.Services;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class CompareProductsController : ControllerBase
    {

       
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();

        Services_ services_ = new Services_();
        
        
      
       
        

        [HttpGet]
        [Route("api/compareproducts")]
        public IActionResult compareproducts([FromBody] Services_.inputproductids productids)
        {
            try
            {
                //if ()
                //{  

                    List<Services_.product> _products = new List<Services_.product>();
                    if (productids.productid1 != 0)
                    { if (services_.checkproductavailability(productids.productid1))
                        {
                            _products.Add(services_.GetProductswithSpecifications(productids.productid1));
                        }
                        else
                        {
                            return BadRequest($"Product with id {productids.productid1} is not found");
                        }

                    }
                    if (productids.productid2 != 0)
                    {
                        if (services_.checkproductavailability(productids.productid2))
                        {
                            _products.Add(services_.GetProductswithSpecifications(productids.productid2)); 
                        }
                        else
                        {
                            return BadRequest($"Product with id {productids.productid2} is not found");
                        }

                    }
                    if (productids.productid3 != 0)
                    {
                        if (services_.checkproductavailability(productids.productid3))
                        {
                            _products.Add(services_.GetProductswithSpecifications(productids.productid3));
                        }
                        else
                        {
                            return BadRequest($"Product with id {productids.productid3} is not found");
                        }
                    }

                    if (productids.productid4 != 0)
                    {
                        if (services_.checkproductavailability(productids.productid4))
                        {
                            _products.Add(services_.GetProductswithSpecifications(productids.productid4));
                        }
                        else
                        {
                            return BadRequest($"Product with id {productids.productid4} is not found");
                        }
                    }
                    if (_products.Count() >= 2)
                     {       

                        return Ok(_products);


                    }
                    else if (_products.Count() == 1)
                    {
                        return BadRequest("Need atleast 2 products to compare");
                    }
                    else
                    {
                        return BadRequest("Cant compare products without selecting " +
                            "atleast 2 products. select atleast 2 products");
                    }
                //}
                //else
                //{
                //    return BadRequest("To compare products all should belong to same category");
                //}




            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
