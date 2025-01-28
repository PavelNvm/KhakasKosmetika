using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface IProductsInBasketRepository
    {
        Task<Guid> AddEntryAsync(Guid userId, string productId);
        Task<string> DeleteEntriesByProductIdAsync(string productId);
        Task<string> DeleteEntriesByUserIdAsync(Guid userId);
        Task<Guid> RemoveSingleProductAsync(Guid userId, string productId);
        Task<List<ProductInBasket>> GetEntriesAsync(Guid userId);
    }
}