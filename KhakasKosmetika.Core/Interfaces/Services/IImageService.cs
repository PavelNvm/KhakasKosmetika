
namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IImageService
    {
        Task<byte[]> GetImagebyCategoryId(string catId);
    }
}