using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IProductsService
    {
        Task<string> AddFavouriteProductAsync(string userId, string productId);
        Task<string> CreateProductAsync(Product product);
        Task<string> DeleteFavouriteProductByProductIdAsync(string productId);
        Task<string> DeleteFavouriteProductsByUserIdAsync(string userId);
        Task<string> DeleteSingleEntryAsync(string userId, string productId);
        Task<List<Product>> GetFavouriteProductsAsync(string userId);
        Task<List<Product>> GetProductsByCategoryIdAsync(string id);
        Task<Product> GetSingleProductByIdAsync(string id);
    }
}