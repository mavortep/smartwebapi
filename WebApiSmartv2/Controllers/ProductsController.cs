using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSmartv2.Infrastructure;

namespace WebApiSmartv2.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            using (ApiProductsEntities db = new ApiProductsEntities())
            {
                return db.Products.ToList();
            }
        }

        public Product Get(Guid id)
        {
            using (ApiProductsEntities db = new ApiProductsEntities())
            {
                return db.Products.FirstOrDefault(x => x.Id == id);
            }
        }

        //[Route("customers/orders")]
        //public IEnumerable<Product> GetCategory()
        //{
        //    using (ApiProductsEntities db = new ApiProductsEntities())
        //    {
        //        return db.Products.OrderBy(x => x.Category).Select(x => x);
        //    }
        //}

        public IEnumerable<Product> Get(string category)
        {
            using (ApiProductsEntities db = new ApiProductsEntities())
            {
                return db.Products.Where(x => x.Category == category).Select(x => x).ToList();
            }
        }
    }
}
