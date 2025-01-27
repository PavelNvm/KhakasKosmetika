
namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<byte[]> GetImagebyCategoryIdAsync(string catId);
    }
}