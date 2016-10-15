using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wcfdacs_ef
{
    [DataContract]
    public class TabelaPreco
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        
        [DataMember]
        public string menuItemOfTheDay {get;set;}

        [DataMember]
        public ICollection<Product> producs { get; set; }

        public TabelaPreco()
        {
            producs = new List<Product>();
        }

        public TypeProduct TypeProduct { get; set; }
    }
}