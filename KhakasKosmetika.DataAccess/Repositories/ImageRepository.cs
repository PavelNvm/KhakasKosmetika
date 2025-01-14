using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using KhakasKosmetika.Core.Interfaces.Repositories;
using System.IO;



namespace KhakasKosmetika.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public ImageRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddImage(string path, string catId)
        {
            ImageEntity picture = new ImageEntity() { Id = Guid.NewGuid(), CategoryId = catId, ImageData = File.ReadAllBytes(path) };
            _context.Images.Add(picture);
            await _context.SaveChangesAsync();
            return catId;
        }
        public async Task<string> UpdateImage(string path, string catId)
        {
            var pic = await _context.Images.FirstOrDefaultAsync(p => p.CategoryId == catId);            
            pic.ImageData = File.ReadAllBytes(path);
            await _context.SaveChangesAsync();
            return catId;
        }
        public async Task<Byte[]?> GetImageByCategoryIdAsync(string catId)
        {
            var res = await _context.Images.AsNoTracking().FirstOrDefaultAsync(p => p.CategoryId == catId);
            if (res != null)
                return res.ImageData;
            else
                //res = await _context.Images.AsNoTracking().FirstOrDefaultAsync(p => p.CategoryId == "0");
            return null;
        }
    }
}
