using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class FavouriteProduct
    {
        private FavouriteProduct(Guid id, Guid userId, string productId)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
        }
        public Guid Id { get; }
        public Guid UserId { get; }
        public string ProductId { get; }
        public static FavouriteProduct Create(Guid id, Guid userId, string productId)
        {
            return new FavouriteProduct(id, userId, productId);
        }
    }
    
}
