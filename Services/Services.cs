using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MockShoppingPriceComparisonApp2._0.Models;
using System;
using System.Text;

namespace MockShoppingPriceComparisonApp2._0.Services
{
    public class Services_
    {
        MockShoppingPriceApp20Context _context = new MockShoppingPriceApp20Context();
      //  private IConfiguration Configuration;
      
        public class inputproductids
        {
            public int productid1 { get; set; }
            public int productid2 { get; set; }
            public int productid3 { get; set; }
            public int productid4 { get; set; }
        }



        public class product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductImage { get; set; }
            public string BrandName { get; set; }
            public string CategoryName { get; set; }
            public double ProductPrice { get; set; }

            public int ProductRating { get; set; }
            public string ProductAvailability { get; set; }
            public List<specifications> Specifications { get; set; }
        }

        public class specifications
        {
            public int ProductId { get; set; }
            public int SpecCatRelId { get; set; }
            public string SpecificationName { get; set; }
            public string SpecificationValue { get; set; }

        }
       

        //check user name
        public bool CheckUsername(string username)
        {
            var _temp = _context.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
            if (_temp == null)
            {
                return false;
            }
            else
                return true;
        }
        //check product availability
        public bool checkproductavailability(int id)
        {
            var _temp = _context.Products.FirstOrDefault(x => x.ProductId == id);


            if (_temp != null && (_temp.Isdeleted == false))
                return true;
            else
                return false;
            
        }

        //get product by id
        public Products getproductbyid(int id)
        {
            Products _product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (_product != null)
                return _product;
            else
                return null;        
        }

        //Check input productids
        public string checkinputproductids(inputproductids productids)
        {   if (!(productids.productid1 == 0 && productids.productid2 == 0 && productids.productid3 == 0 && productids.productid4 == 0))
            {   if (!(productids.productid2 == 0 && productids.productid3 == 0 && productids.productid4 == 0))
                {
                    return "atleast2entered";
                }
                else
                {
                    return "3null";
                }
               
            }
            else
                return "4null";
        }

        public product GetProductswithSpecifications(int productid)
        {
            var _product = getproductbyid(productid);
            List<specifications> _specifications = new List<specifications>();
            _specifications = getproductspecifications(productid);

            return new product
            {   ProductId = _product.ProductId,
                ProductName = _product.ProductName,
                BrandName = _context.Brands.FirstOrDefault(x => x.BrandId == _product.BrandId).BrandName,
                CategoryName = _context.Category.FirstOrDefault(x => x.CategoryId == _product.CategoryId).CategoryName,
                ProductPrice = _product.ProductPrice,
                ProductRating = _product.ProductRating,
                ProductAvailability= _product.ProductAvailability,
                Specifications = _specifications,
                ProductImage = _product.ProductImage
            };

        }

        public List<specifications> getproductspecifications(int productid)
        {
            List<specifications> productspecifications = new List<specifications>();
            var _result = ( from a in _context.Specifications
                            join b in _context.SpecificationsCategoryRelation on a.SpecificationId equals b.SpecificationId
                            join c in _context.ProductSpecifications on b.SpecCatRelId equals c.SpecCatId

                            select new specifications
                            {
                                ProductId = c.ProductId,
                                SpecCatRelId = c.SpecCatId,
                                SpecificationName = a.SpecificationName,
                                SpecificationValue = c.SpecificationValue
                            }
                ).ToList();
            productspecifications = _result.Where( x=>x.ProductId == productid).ToList();
            return productspecifications;
        
        }
        public static string key = "psiogdigital"; 
        public string encryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        
        }


        public string decryptPassword(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        
        }

        public List<int> top5Products()
        {

            try
            {
                Dictionary<int, int> top5Products = new Dictionary<int, int>();
                List<Comparison> _comparisonRecords = _context.Comparison.ToList();
                for (int i = 0; i < _comparisonRecords.Count(); i++)
                {
                    if (_comparisonRecords[i].ProductId1 != null)
                    {
                        if (top5Products.Keys.Contains(_comparisonRecords[i].ProductId1))
                        {
                            top5Products[_comparisonRecords[i].ProductId1] += 1;
                        }
                        else
                        {
                            top5Products.Add(_comparisonRecords[i].ProductId1, 1);
                        }
                    
                    }
                    if (_comparisonRecords[i].ProductId2 != null)
                    {
                        if (top5Products.Keys.Contains(_comparisonRecords[i].ProductId2))
                        {
                            top5Products[_comparisonRecords[i].ProductId2] += 1;
                        }
                        else
                        {
                            top5Products.Add(_comparisonRecords[i].ProductId2, 1);
                        }
                    
                    }
                    if (_comparisonRecords[i].ProductId3 != null)
                    {
                        if (top5Products.Keys.Contains(Convert.ToInt32(_comparisonRecords[i].ProductId3)))
                        {
                            top5Products[Convert.ToInt32(_comparisonRecords[i].ProductId3)] += 1;
                        }
                        else
                        {
                            top5Products.Add(Convert.ToInt32(_comparisonRecords[i].ProductId3), 1);
                        }
                    
                    } if (_comparisonRecords[i].ProductId4 != null)
                    {
                        if (top5Products.Keys.Contains(Convert.ToInt32(_comparisonRecords[i].ProductId4)))
                        {
                            top5Products[Convert.ToInt32(_comparisonRecords[i].ProductId4)] += 1;
                        }
                        else
                        {
                            top5Products.Add(Convert.ToInt32(_comparisonRecords[i].ProductId4), 1);
                        }
                    
                    }
                }

                top5Products = top5Products.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


                List<int> top5ids = new List<int>();
                int _count = 0;
                foreach (KeyValuePair<int, int> ids in top5Products)
                {
                    if (_count >= 5)
                    {
                        _count = 0;
                        break;
                    }
                    else
                    {
                        top5ids.Add(ids.Key);
                        _count++;

                    }
                
                }
                return top5ids;


            }
            catch (Exception e)
            {
                return null;
            }



        }






    }
}
