using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSmartv2.DTO;
using WebApiSmartv2.Infrastructure;

namespace WebApiSmartv2.Controllers
{
    public class ProductsController : ApiController
    {
        //Get list of products
        public IQueryable<ProductDTO> Get()
        {
            ApiProductsEntities db = new ApiProductsEntities();

            var query = from product in db.Products
                         join category in db.Categories on product.CategoryId equals category.Id
                         select new ProductDTO { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description, Category = category.Name };

            return query;
        }

        //Get product info by id (3)
        public ProductDTO Get(Guid id)
        {
            using (ApiProductsEntities db = new ApiProductsEntities())
            {
                var query = (from product in db.Products
                            join category in db.Categories on product.CategoryId equals category.Id
                            select new ProductDTO
                            { Id = product.Id,
                              Name = product.Name,
                              Price = product.Price,
                              Description = product.Description,
                              Category = category.Name
                            }).FirstOrDefault(x => x.Id == id);

                return query;
            }
        }
    }
}
