using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Entities
{
    public class RatingOfProductByUserEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProductId { get; set; } = "";
        public int Rating { get; set; }
        public RatingOfProductByUserEntity(Guid id,Guid userId, string productId, int rating)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Rating = rating;
        }
    }
}
