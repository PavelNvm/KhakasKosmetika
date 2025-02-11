using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; }
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string House { get; set; } = "";


    }
}
