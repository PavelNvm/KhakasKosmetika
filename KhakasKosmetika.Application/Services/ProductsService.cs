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
        private readonly IFavouriteProductsRepository _favouriteProductsRepository;
        public ProductsService(ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IFavouriteProductsRepository favouriteProductsRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _favouriteProductsRepository = favouriteProductsRepository;
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
        public async Task<string> AddFavouriteProductAsync(string userId, string productId)
        {
            var res = await _favouriteProductsRepository.CreateEntryAsync(Guid.Parse(userId), productId);
            return res;
        }

        public async Task<List<Product>> GetFavouriteProductsAsync(string userId)
        {
            var FPs = await _favouriteProductsRepository.GetEntries(Guid.Parse(userId));
            List<Product> res = new List<Product>();
            foreach (var fp in FPs)
            {
                res.Add(await _productRepository.GetSingleProductByIdAsync(fp.ProductId));
            }
            return res;
        }
        public async Task<string> DeleteSingleEntryAsync(string userId, string productId)
        {
            var res = await _favouriteProductsRepository.DeleteSingleEntry(Guid.Parse(userId), productId);
            return res;
        }
        public async Task<string> DeleteFavouriteProductByProductIdAsync(string productId)
        {
            var res = await _favouriteProductsRepository.DeleteEntriesByProductId(productId);
            return res;
        }
        public async Task<string> DeleteFavouriteProductsByUserIdAsync(Guid userId)
        {
            var res = await _favouriteProductsRepository.DeleteEntriesByUserId(userId);

            return res;
        }

    }
}
