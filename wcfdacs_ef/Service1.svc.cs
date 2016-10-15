using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfdacs_ef
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void AddTabelaPreco(TabelaPreco tp)
        {
            using (var context = new WebServiceDBContext())
            {
                foreach (Product p in tp.producs){
                    context.Produtcs.Attach(p);
                    context.Entry(p).State = EntityState.Unchanged;
                }
                
                context.TabelaPrecos.Add(tp);
                context.SaveChanges();
            }
        }

        public void RemoveTabelaPreco(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                TabelaPreco tab = context.TabelaPrecos.Find(id);
                context.Entry(tab).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TabelaPreco GetTabelaPreco(long id)
        {
            TabelaPreco tab = null;

            using (var context = new WebServiceDBContext())
            {
                tab = context.TabelaPrecos.Find(id);
            }

            return tab;
        }

        public void UpdateTabelaPreco(TabelaPreco tab)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(tab).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Product GetProduct(long id)
        {
            Product prod = null;

            using(var context = new WebServiceDBContext())
            {
                prod = context.Produtcs.Find(id);
            }
            
            return prod;
        }

        public void AddProduct(Product p)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Produtcs.Add(p);
                context.SaveChanges();
            }
        }

        public void RemoveProduct(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                Product product = context.Produtcs.Find(id);
                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product p)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void AddTypeProduct(TypeProduct typePro)
        {
            using (var context = new WebServiceDBContext())
            { 
                context.TypeProduct.Add(typePro);
                context.SaveChanges();
            }
        }

        public void UpdateTypeProduct(TypeProduct typePro)
        {
            using (var context = new WebServiceDBContext())
            {
                context.Entry(typePro).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TypeProduct GetTypeProduct(long id)
        {
            TypeProduct tproduct = null;

            using (var context = new WebServiceDBContext())
            {
                tproduct = context.TypeProduct.Find(id);
            }

            return tproduct;

        }

        public void RemoveTypeProduct(long id)
        {
            using (var context = new WebServiceDBContext())
            {
                TypeProduct tproduct = context.TypeProduct.Find(id);
                context.Entry(tproduct).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ICollection<TypeProduct> GetAllTypeProduct()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.TypeProduct.ToList();
            }
        }


        public ICollection<Product> GetAll()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.Produtcs.ToList();
            }
        }

        public ICollection<TabelaPreco> GetAllTabelaPreco()
        {
            using (var context = new WebServiceDBContext())
            {
                return context.TabelaPrecos.ToList();
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
