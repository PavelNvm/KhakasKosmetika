using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Application.Services
{
    public class BasketService
    {
        private readonly IProductsInBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        public BasketService(IProductsInBasketRepository basketRepository,
            IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }
        public async Task<List<ProductInBasket>> GetBasketByUserIdAsync(Guid userId)
        {
            List<ProductInBasket> basketEntries = await _basketRepository.GetEntriesAsync(userId);
            return basketEntries;
        }
        public async Task<Guid> AddProductToBasketAsync(Guid userId, string productId)
        {
            var res = await _basketRepository.AddEntryAsync(userId, productId);
            return res;
        }






    }
}
