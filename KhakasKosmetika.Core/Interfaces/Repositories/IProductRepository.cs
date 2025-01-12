using KhakasKosmetika.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<string> CreateProductAsync(Product product);
        Task<List<Product>> GetProductsByCategoryIdAsync(string catId);
        Task<Product> GetSingleProductByIdAsync(string id);
    }
}
