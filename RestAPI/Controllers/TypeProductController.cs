using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class TypeProductController : ApiController
    {
        public TypeProduct Get(long id)
        {

            TypeProduct tp = null;

            using (var context = new WebServiceDBContext())
            {
                tp = context.TypeProduct.Find(id);
            }
            
            return tp;

        }
        
        public ICollection<TypeProduct> Get()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.TypeProduct.ToList();
            }
        }

        public void Post([FromBody]TypeProduct tp)
        {
           using (var context = new WebServiceDBContext())
            {
                context.TypeProduct.Add(tp);
                context.SaveChanges();
            }
        }

        public void Put([FromBody]TypeProduct tp)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(tp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public HttpResponseMessage Delete(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                TypeProduct tp = context.TypeProduct.Find(id);
                
                context.Entry(tp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
        
    }
}
