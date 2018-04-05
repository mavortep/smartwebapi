using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiSmartv2.Abstract;
using WebApiSmartv2.Infrastructure;

namespace WebApiSmartv2.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        ApiProductsEntities db = new ApiProductsEntities();
        public IEnumerable<Product> Products
        {
            get { return db.Products; }
        }
    }
}