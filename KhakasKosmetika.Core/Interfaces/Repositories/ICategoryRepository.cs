using KhakasKosmetika.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesBySuperCatIdAsync(string superCatId);
        Task<Category> GetCategoryByIdAsync(string id);
        Task<List<Category>> GetCategoriesDepthZeroAsync();
        Task<string> CreateCategoryAsync(Category category);
    }
}
