using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using KhakasKosmetika.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoriesService(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public async Task<string> GetCategoryNameById(string categoryId)
        {
            var res = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return res.Name;
        }
        public async Task<List<Category>> GetCategoriesDepthZero()
        {
            var res = await _categoryRepository.GetCategoriesDepthZeroAsync();

            return res;
        }
        public async Task<List<Category>> GetFilledCategoriesById(string categoryId)
        {
            var temp = await _categoryRepository.GetCategoriesBySuperCatIdAsync(categoryId);
            var tempProd = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            List<Category> res = new List<Category>();
            foreach (var category in temp)
            {
                foreach (var product in tempProd)
                {
                    if (product.Categories.Contains(category.Id))
                    {
                        res.Add(category);
                        break;
                    }
                }
            }
            return res;
        }
        public async Task<string> CreateCategoryAsync(Category category)
        {
            await _categoryRepository.CreateCategoryAsync(category);
            return category.Id;
        }
    }
}
