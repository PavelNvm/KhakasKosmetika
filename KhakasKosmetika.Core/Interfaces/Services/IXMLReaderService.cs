using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KhakasKosmetika.Core.Models;
    
namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IXMLReaderService
    {
        Task<List<Category>> ReadCategories();
        Task<List<PriceType>> ReadPriceTypes();
        Task<List<MeasurementUnit>> ReadMeasurementUnits();
        Task<List<Product>> ReadProducts();
    }
}
