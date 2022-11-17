using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ASPWebAPI5.Controllers
{
    [Route("api/[controller]")] 
    public class ProductsController : Controller
    {
        // GET: Products
  //      [HttpGet("{id}")]
        public int GetProduct(int id)
        {
          // Search for some product/ and return ID
           return id + 5;
        }
    }
}