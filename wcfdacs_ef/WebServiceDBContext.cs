using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wcfdacs_ef
{
    public class WebServiceDBContext:DbContext
    {
        public WebServiceDBContext()
            : base("dbwebservice")
        { }
        public DbSet<Product> Produtcs { get; set; }
        public DbSet<TabelaPreco> TabelaPrecos { get; set; }
        public DbSet<TypeProduct> TypeProduct { get; set; }
    }
}