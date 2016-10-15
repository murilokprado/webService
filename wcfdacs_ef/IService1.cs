using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfdacs_ef
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Product GetProduct(long id);

        [OperationContract]
        void AddProduct(Product p);

        [OperationContract]
        void RemoveProduct(long id);

        [OperationContract]
        void UpdateProduct(Product p);

        [OperationContract]
        void AddTabelaPreco(TabelaPreco tp);

        [OperationContract]
        void UpdateTabelaPreco(TabelaPreco tab);

        [OperationContract]
        void RemoveTabelaPreco(long id);

        [OperationContract]
        ICollection<TabelaPreco> GetAllTabelaPreco();

        [OperationContract]
        TabelaPreco GetTabelaPreco(long id);

        [OperationContract]
        ICollection<Product> GetAll();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void AddTypeProduct(TypeProduct typePro);

        [OperationContract]
        void UpdateTypeProduct(TypeProduct typePro);

        [OperationContract]
        TypeProduct GetTypeProduct(long id);

        [OperationContract]
        void RemoveTypeProduct(long id);

        [OperationContract]
        ICollection<TypeProduct> GetAllTypeProduct();

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
