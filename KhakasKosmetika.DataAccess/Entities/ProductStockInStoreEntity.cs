using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class ProductStockInStoreEntity
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string ProductId { get; set; }
        public string Amount { get; set; }
    }
}
