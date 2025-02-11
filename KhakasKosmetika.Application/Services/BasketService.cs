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
        public async Task<List<(Product,int)>> GetBasketByUserIdAsync(string userId)
        {
            var basketEntries = await _basketRepository.GetEntriesAsync(Guid.Parse(userId));
            List<(Product, int)> products = new List<(Product, int)>();
            foreach (var basketEntry in basketEntries)
            {
                products.Add((await _productRepository.GetSingleProductByIdAsync(basketEntry.ProductId),basketEntry.Amount));
            }
            return products;
        }
        public async Task<string> AddProductToBasketAsync(string userId, string productId)
        {
            var res = await _basketRepository.AddEntryAsync(Guid.Parse(userId), productId);
            return res.ToString();
        }
        public async Task<string> RemoveSingleProductAsync(string userId, string productId)
        {
            var res = await _basketRepository.RemoveSingleProductAsync(Guid.Parse(userId), productId);
            return res.ToString();
        }

        public async Task<string> ClearBasketByUserIdAsync(string userId)
        {
            var res = await _basketRepository.DeleteEntriesByUserIdAsync(Guid.Parse(userId));
            return res.ToString();
        }



    }
}
