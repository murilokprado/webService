using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Models
{
    public class Cliente
    {
        public long id { get; set; }

        public string nome { get; set; }

        public int idade { get; set; }
    }
}