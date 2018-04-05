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
    public class CategoriesController : ApiController
    {
        //Get list of products by category id (2)
        public IQueryable<ProductDTO> Get(Guid id)
        {
            ApiProductsEntities db = new ApiProductsEntities();
                List<string> products = new List<string>();

                var query = from product in db.Products
                             join category in db.Categories on product.CategoryId equals category.Id
                            where category.Id == id
                             select new ProductDTO
                             {
                                 Id = product.Id,
                                 Name = product.Name,
                                 Price = product.Price,
                                 Description = product.Description,
                                 Category = category.Name
                             };

                return query;
        }

        //Get list of categories (1)
        public List<string> Get()
        {
            using (ApiProductsEntities db = new ApiProductsEntities())
            {
                List<string> categories = new List<string>();

                foreach (var category in db.Categories)
                {
                    categories.Add(category.Name);
                }

                return categories;
            }
        }
    }
}
