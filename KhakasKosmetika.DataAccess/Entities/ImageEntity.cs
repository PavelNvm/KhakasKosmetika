using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public string CategoryId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
