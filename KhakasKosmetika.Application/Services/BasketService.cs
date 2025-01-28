using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;


namespace KhakasKosmetika.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IProductsInBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        public BasketService(IProductsInBasketRepository basketRepository,
            IProductRepository productRepository)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
        }
        public async Task<List<(Product,int)>> GetBasketByUserIdAsync(Guid userId)
        {
            var basketEntries = await _basketRepository.GetEntriesAsync(userId);
            List<(Product, int)> products = new List<(Product, int)>();
            foreach (var basketEntry in basketEntries)
            {
                products.Add((await _productRepository.GetSingleProductByIdAsync(basketEntry.ProductId),basketEntry.Amount));
            }
            return products;
        }
        public async Task<Guid> AddProductToBasketAsync(Guid userId, string productId)
        {
            var res = await _basketRepository.AddEntryAsync(userId, productId);
            return res;
        }
        public async Task<Guid> RemoveSingleProductAsync(Guid userId, string productId)
        {
            var res = await _basketRepository.RemoveSingleProductAsync(userId, productId);
            return res;
        }

        public async Task<Guid> ClearBasketByUserIdAsync(Guid userId)
        {
            var res = await _basketRepository.DeleteEntriesByUserIdAsync(userId);
            return res;
        }



    }
}
