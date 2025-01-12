using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Models;
using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Repositories
{
    

    public class CategoryRepository : ICategoryRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public CategoryRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            var res = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return Category.Create(res.Id, res.SupergroupId, res.Name, res.Version, res.DeletionMarker, res.Depth);
        }
        public async Task<List<Category>> GetCategoriesBySuperCatIdAsync(string superCatId)
        {
            var res = await _context.Categories.AsNoTracking().Where(c => c.SupergroupId.Contains(superCatId)).Select(c => Category.Create(c.Id, c.SupergroupId, c.Name, c.Version, c.DeletionMarker, c.Depth)).ToListAsync();
            return res;
        }
        public async Task<List<Category>> GetCategoriesDepthZeroAsync()
        {
            var res = await _context.Categories.AsNoTracking().Where(c => c.Depth==0).Select(c => Category.Create(c.Id, c.SupergroupId, c.Name, c.Version, c.DeletionMarker, c.Depth)).ToListAsync();
            return res;
        }
        public async Task<string> CreateCategoryAsync(Category category)
        {
            var cat = new CategoryEntity()
            {
                Id = category.Id,
                SupergroupId = category.SupergroupId,
                Name = category.Name,
                Version = category.Version,
                DeletionMarker = category.DeletionMarker,
                Depth = category.Depth
            };
            await _context.Categories.AddAsync(cat);
            await _context.SaveChangesAsync();
            return cat.Id;
        }
    }
}
