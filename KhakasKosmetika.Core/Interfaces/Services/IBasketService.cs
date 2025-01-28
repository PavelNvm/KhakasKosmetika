using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IBasketService
    {
        Task<Guid> AddProductToBasketAsync(Guid userId, string productId);
        Task<List<(Product, int)>> GetBasketByUserIdAsync(Guid userId);
        Task<Guid> RemoveSingleProductAsync(Guid userId, string productId);
    }
}