using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class ProductInBasket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public static ProductInBasket Create(Guid id, Guid userId, string productId, int amount)
        {
            return new ProductInBasket(id, userId, productId, amount);
        }
        private ProductInBasket(Guid id, Guid userId, string productId, int amount)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Amount = amount;
        }
    }
}
