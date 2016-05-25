using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StoreApp.Controllers
{
    public class ProductController : ApiController
    {

        private StoreIDBEntities Entity;

        public ProductController()
        {
            this.Entity = new StoreIDBEntities();
        }

        public ProductController(StoreIDBEntities entity)
        {
            this.Entity = entity;
        }

        public IEnumerable<product> GetAllProducts()
        {
            List<product> products = this.Entity.products.ToList();
            return products;
        }

    }
}
