using KhakasKosmetika.Core.Models;
using Microsoft.EntityFrameworkCore;
using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace KhakasKosmetika.DataAccess.Repositories
{
    public class ProductsInBasketRepository : IProductsInBasketRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public ProductsInBasketRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddEntryAsync(Guid userId, string productId)
        {
            var prod = await _context.ProductsInBasket.FirstOrDefaultAsync(o => o.UserId == userId && o.ProductId == productId);
            if (prod == null)
            {
                var id = Guid.NewGuid();
                await _context.ProductsInBasket.AddAsync(new Entities.ProductInBasketEntity(id, userId, productId, 1) );
                await _context.SaveChangesAsync();
                return id;
            }
            else
            {
                prod.Amount++;
                await _context.SaveChangesAsync();
                return prod.Id;
            }
        }
        public async Task<List<ProductInBasket>> GetEntriesAsync(Guid userId)
        {
            var res = await _context.ProductsInBasket.AsNoTracking().Where(o => o.UserId == userId).Select(o => ProductInBasket.Create(o.Id, o.UserId, o.ProductId,o.Amount)).ToListAsync();
            return res;
        }
        public async Task<Guid> RemoveSingleProductAsync(Guid userId, string productId)
        {
            var ent = await _context.ProductsInBasket.FirstOrDefaultAsync(o => o.UserId == userId && o.ProductId == productId);
            if (ent != null)
            {
                if (ent.Amount == 1)
                {
                    _context.ProductsInBasket.Remove(ent);
                    await _context.SaveChangesAsync();
                    return ent.Id;
                }
                else 
                {
                    ent.Amount--;
                    await _context.SaveChangesAsync();
                    return ent.Id;
                }
            }
            return Guid.Empty;
        }
        public async Task<Guid> DeleteEntriesByUserIdAsync(Guid userId)
        {
            var enteties = await _context.ProductsInBasket.Where(o => o.UserId == userId).ToListAsync();
            foreach (var entry in enteties)
            {
                if (entry != null)
                {
                    _context.ProductsInBasket.Remove(entry);
                }
            }
            await _context.SaveChangesAsync();
            return userId;
        }
        public async Task<string> DeleteEntriesByProductIdAsync(string productId)
        {
            var enteties = await _context.ProductsInBasket.Where(o => o.ProductId == productId).ToListAsync();
            foreach (var entry in enteties)
            {
                if (entry != null)
                {
                    _context.ProductsInBasket.Remove(entry);
                }
            }
            await _context.SaveChangesAsync();
            return productId;
        }





    }
}
