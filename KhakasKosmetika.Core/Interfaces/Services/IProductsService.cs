using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IProductsService
    {
        Task<string> CreateProductAsync(Product product);
        Task<List<Product>> GetProductsByCategoryIdAsync(string id);
        Task<Product> GetSingleProductByIdAsync(string id);
    }
}