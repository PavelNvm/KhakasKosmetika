using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Models;
using KhakasKosmetika.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public ProductsService(ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(string id)
        {
            var res = await _productRepository.GetProductsByCategoryIdAsync(id);

            return res;
        }
        public async Task<Product> GetSingleProductByIdAsync(string id)
        {
            var res = await _productRepository.GetSingleProductByIdAsync(id);

            return res;
        }

        public async Task<string> CreateProductAsync(Product product)
        {
            await _productRepository.CreateProductAsync(product);
            return product.Id;
        }


    }
}
