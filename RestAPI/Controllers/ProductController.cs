using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class ProductController : ApiController
    {
        public Product Get(long id)
        {
            
            Product prod = null;

            using (var context = new WebServiceDBContext())
            {
                prod = context.Produtcs.Find(id);
            }
            
            return prod;

        }
        
        public ICollection<Product> Get()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.Produtcs.ToList();
            }
        }

        public void Post([FromBody]Product p)
        {
           using (var context = new WebServiceDBContext())
            {
                context.Produtcs.Add(p);
                context.SaveChanges();
            }
        }

        public void Put([FromBody]Product p)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public HttpResponseMessage Delete(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                Product product = context.Produtcs.Find(id);
                
                context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        
    }
}
