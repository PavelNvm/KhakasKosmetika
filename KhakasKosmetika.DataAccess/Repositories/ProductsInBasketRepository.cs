using KhakasKosmetika.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Repositories
{
    public class ProductsInBasketRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public ProductsInBasketRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }
        //CRUD

        public async Task<Guid> AddEntryAsync(Guid userId, string productId)
        {
            var prod = await _context.ProductsInBasket.FirstOrDefaultAsync(o => o.UserId == userId && o.ProductId == productId);
            if (prod==null)
            {
                var id = Guid.NewGuid();
                await _context.ProductsInBasket.AddAsync(new Entities.ProductInBasketEntity() { Id = id, UserId = userId, ProductId = productId,Amount=1 });
                await _context.SaveChangesAsync();
                return id;
            }
            else
            { 
                prod.Amount++;
                return prod.Id;
            }
        }
        public async Task<List<FavouriteProduct>> GetEntries(Guid userId)
        {
            var res = await _context.ProductsInBasket.AsNoTracking().Where(o => o.UserId == userId).Select(o => new FavouriteProduct(o.Id, o.UserId, o.ProductId)).ToListAsync();
            return res;
        }
        public async Task<Guid> DeleteSingleEntry(Guid userId, string productId)
        {
            var ent = await _context.ProductsInBasket.FirstOrDefaultAsync(o => o.UserId == userId && o.ProductId == productId);
            if (ent != null)
            {
                _context.ProductsInBasket.Remove(ent);
                await _context.SaveChangesAsync();
                return ent.Id;
            }
            return Guid.Empty;
        }
        public async Task<string> DeleteEntriesByUserId(Guid userId)
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
            return userId.ToString();
        }
        public async Task<string> DeleteEntriesByProductId(string productId)
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
