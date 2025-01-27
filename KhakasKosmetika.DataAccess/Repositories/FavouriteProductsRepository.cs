using KhakasKosmetika.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using KhakasKosmetika.Core.Interfaces.Repositories;

namespace KhakasKosmetika.DataAccess.Repositories
{
    public class FavouriteProductsRepository : IFavouriteProductsRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public FavouriteProductsRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateEntryAsync(Guid userId, string productId)
        {
            if (!await _context.FavouriteProducts.AnyAsync(o => o.UserId == userId && o.ProductId == productId))
            {
                var id = Guid.NewGuid();
                await _context.FavouriteProducts.AddAsync(new Entities.FavouriteProductEntity() { Id = id, UserId = userId, ProductId = productId });
                await _context.SaveChangesAsync();
                return id.ToString();
            }
            else return (await _context.FavouriteProducts.FirstOrDefaultAsync(o => o.UserId == userId && o.ProductId == productId)).Id.ToString();
        }
        public async Task<List<FavouriteProduct>> GetEntries(Guid userId)
        {
            var res = await _context.FavouriteProducts.AsNoTracking().Where(o => o.UserId == userId).Select(o => FavouriteProduct.Create(o.Id, o.UserId, o.ProductId)).ToListAsync();
            return res;
        }
        public async Task<string> DeleteSingleEntry(Guid userId, string productId)
        {
            var ent = await _context.FavouriteProducts.FirstOrDefaultAsync(o => o.UserId == userId&&o.ProductId==productId);
            if (ent != null)
            {
                _context.FavouriteProducts.Remove(ent);
                await _context.SaveChangesAsync();
            }
            return ent.Id.ToString();
        }
        public async Task<string> DeleteEntriesByUserId(Guid userId)
        {
            var enteties = await _context.FavouriteProducts.Where(o => o.UserId == userId).ToListAsync();
            foreach (var entry in enteties)
            {
                if (entry != null)
                {
                    _context.FavouriteProducts.Remove(entry);
                }
            }
            await _context.SaveChangesAsync();
            return userId.ToString();
        }
        public async Task<string> DeleteEntriesByProductId(string productId)
        {
            var enteties = await _context.FavouriteProducts.Where(o => o.ProductId == productId).ToListAsync();
            foreach (var entry in enteties)
            {
                if (entry != null)
                {
                    _context.FavouriteProducts.Remove(entry);
                }
            }            
            await _context.SaveChangesAsync();
            return productId;
        }
        
    }
}
