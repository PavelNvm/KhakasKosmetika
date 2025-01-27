namespace KhakasKosmetika.DataAccess.Entities
{
    public class ProductInBasketEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
        public ProductInBasketEntity(Guid id, Guid userId, string productId, int amount)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Amount = amount;
        }
    }
}
