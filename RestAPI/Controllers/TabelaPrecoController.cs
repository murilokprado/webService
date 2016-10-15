using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class TabelaPrecoController : ApiController
    {
        public TabelaPreco Get(long id)
        {

            TabelaPreco tb = null;

            using (var context = new WebServiceDBContext())
            {
                tb = context.TabelaPrecos.Find(id);
            }

            return tb;

        }

        public ICollection<TabelaPreco> Get()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.TabelaPrecos.ToList();
            }
        }

        public void Post([FromBody]TabelaPreco tp)
        {
            using (var context = new WebServiceDBContext())
            {
                foreach (Product p in tp.producs)
                {
                    context.Produtcs.Attach(p);
                    context.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                }

                context.TabelaPrecos.Add(tp);
                context.SaveChanges();
            }
        }

        public void Put([FromBody]TabelaPreco tb)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(tb).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public HttpResponseMessage Delete(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                TabelaPreco tb = context.TabelaPrecos.Find(id);

                context.Entry(tb).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

    }
}
