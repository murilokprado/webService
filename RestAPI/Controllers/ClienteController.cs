using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class ClienteController : ApiController
    {
        public Cliente Get(long id)
        {
            Cliente c = new Cliente()
            {
                id=10, nome="zezinho", idade=20
            };

            return c;
        }

        public ICollection<Cliente> Get()
        {
            ICollection<Cliente> colClientes = new List<Cliente>();

            colClientes.Add(new Cliente()
            {
                id = 10,
                nome = "zezinho",
                idade = 20
            });

            colClientes.Add(new Cliente()
            {
                id = 20,
                nome = "Luizinho",
                idade = 200
            });

            return colClientes;
        }

        public void Post([FromBody]Cliente cliente)
        {

        }

        public void Put([FromBody]Cliente cliente)
        {

        }

        public HttpResponseMessage Delete(long id)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
