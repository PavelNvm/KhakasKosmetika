using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IBasketService
    {
        Task<string> AddProductToBasketAsync(string userId, string productId);
        Task<List<(Product, int)>> GetBasketByUserIdAsync(string userId);
        Task<string> RemoveSingleProductAsync(string userId, string productId);
        Task<string> ClearBasketByUserIdAsync(string userId);
    }
}