

namespace KhakasKosmetika.DataAccess.Entities
{
    public class ProductInPurchaseEntity
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; } = "";
        public int Amount { get; set; }
    }
}
