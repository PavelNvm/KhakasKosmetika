using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class PriceType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Currency{ get; set; }
        public string TaxName { get; set; }
        public bool TaxCounted { get; set; }
        //1C remains                               
        public string Version { get; set; }        //<НомерВерсии>
        public bool DeletionMarker { get; set; }   //<ПометкаУдаления>
        public PriceType(string id, string name, string currency, string taxName, bool taxCounted, string version, bool deletionMarker)
        {
            Id = id;
            Name = name;
            Currency = currency;
            TaxName = taxName;
            TaxCounted = taxCounted;
            Version = version;
            DeletionMarker = deletionMarker;
        }
    }
}
