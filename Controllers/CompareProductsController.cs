using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockShoppingPriceComparisonApp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MockShoppingPriceComparisonApp2._0.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MockShoppingPriceComparisonApp2._0.Controllers
{

    public class CompareProductsController : ControllerBase
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
        Services_ _services = new Services_();        
       

        [HttpPost]
        [Route("api/compareproducts")]
        [Authorize]
        public IActionResult _compareproducts([FromBody] int[] productids)
        {
            try
            {
                List<Services_.product> _products = new List<Services_.product>();
                if (productids.Length < 2)
                {

                    return BadRequest("Need atleast two productids to compare");
                }
                else if (productids.Length > 4)
                {
                    return BadRequest("Max of 4 products can be compared at once");
                }
                else
                {
                    for (int i = 0; i < productids.Length; i++)
                    {       if (_services.checkproductavailability(productids[i]))
                        {
                            _products.Add(_services.GetProductswithSpecifications(productids[i]));

                        }
                        else
                        {
                            return BadRequest($"Product with id {productids[i]} is not found");
                        }
                    }
                    if (_products.Count() >= 2)
                    {
                        var _currentuser = currentuser();
                        var _comparisonrecord = new Comparison();
                        if (productids.Length == 2)
                        {
                            _comparisonrecord = new Comparison
                            {
                                UserId = _currentuser.UserId,
                                ComparisonDate = DateTime.Now,
                                ProductId1 = productids[0],
                                ProductId2 = productids[1]

                            };

                        }
                        else if (productids.Length == 3)
                        {
                            _comparisonrecord = new Comparison
                            {
                                UserId = _currentuser.UserId,
                                ComparisonDate = DateTime.Now,
                                ProductId1 = productids[0],
                                ProductId2 = productids[1],
                                ProductId3 = productids[2]

                            };
                        }
                        else
                        {
                            _comparisonrecord = new Comparison
                            {
                                UserId = _currentuser.UserId,
                                ComparisonDate = DateTime.Now,
                                ProductId1 = productids[0],
                                ProductId2 = productids[1],
                                ProductId3 = productids[2],
                                ProductId4 = productids[3]
                            };
                        }


                        //return Ok(_comparisonrecord);
                        _context.Comparison.Add(_comparisonrecord);
                        _context.SaveChanges();

                        return Ok(_products);

                    }
                    else
                    {
                        return BadRequest("Need atleast 2 product ids to compare");
                    }
                        

                
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }





        [HttpGet]
        [Route("api/getcurrentuser")]
        public Users currentuser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userclaims = identity.Claims;
                return new Users
                {
                    UserName = userclaims.FirstOrDefault(o => o.Type == "UserName")?.Value,
                    UserEmail = userclaims.FirstOrDefault(o => o.Type == "Email")?.Value,
                    UserGivenName = userclaims.FirstOrDefault(o => o.Type == "Givenname")?.Value,
                    UserRole = userclaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    UserId = (int)Convert.ToInt32(userclaims.FirstOrDefault(o => o.Type == "UserId")?.Value)
                };
            }
            else
                return null;
        }
    }

   
}
