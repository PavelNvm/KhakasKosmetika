using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Models;
using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KhakasKosmetika.DataAccess.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public ProductRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetSingleProductByIdAsync(string id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return Product.Create(
                result.Id,
                result.Art,
                result.Code,
                result.Lenght,
                result.Width,
                result.Height,
                result.Diameter,
                result.Volume,
                result.Weight,
                result.Name,
                result.PriceLow,
                result.PriceFull,
                result.Rests,
                result.Version,
                result.DeletionMarker.ToString(),
                result.AmountOfCategories,
                result.Categories,
                result.PhotoLink,
                result.AverageRating,
                result.Description
                );
        }
        public async Task<List<Product>> GetProductsByCategoryIdAsync(string catId)
        {
            var result = await _context.Products
                .AsNoTracking()
                .Where(c => c.Categories.Contains(catId))
                .Select(p => Product.Create(
                p.Id,
                p.Art,
                p.Code,
                p.Lenght,
                p.Width,
                p.Height,
                p.Diameter,
                p.Volume,
                p.Weight,
                p.Name,
                p.PriceLow,
                p.PriceFull,
                p.Rests,
                p.Version,
                p.DeletionMarker.ToString(),
                p.AmountOfCategories,
                p.Categories,
                p.PhotoLink,
                p.AverageRating,
                p.Description
                ))
                .ToListAsync();
            return result;
        }
        public async Task<string> CreateProductAsync(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Art = product.Art,
                Code = product.Code,
                Lenght = product.Lenght,
                Width = product.Width,
                Height = product.Height,
                Diameter = product.Diameter,
                Volume = product.Volume,
                Weight = product.Weight,
                Name = product.Name,
                PriceLow = product.PriceLow,
                PriceFull = product.PriceFull,
                Rests = product.Rests,
                Version = product.Version,
                DeletionMarker = product.DeletionMarker,
                AmountOfCategories = product.AmountOfCategories,
                Categories = product.Categories,
                PhotoLink = product.PhotoLink
            };
            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();
            return productEntity.Id;
        }
        public async Task<string> RateProduct(Guid userId, string productId,int rating)
        {
            var ratingOfProduct = new RatingOfProductByUserEntity(Guid.NewGuid(), userId, productId, rating);
            //await _context.

            return "0";
        }



    }
}
