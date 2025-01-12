using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface ICategoriesService
    {
        Task<string> CreateCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesDepthZero();
        Task<string> GetCategoryNameById(string categoryId);
        Task<List<Category>> GetFilledCategoriesById(string categoryId);
    }
}