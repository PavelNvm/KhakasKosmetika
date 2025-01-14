
namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface IImageRepository
    {
        Task<string> AddImage(string path, string catId);
        Task<byte[]> GetImageByCategoryIdAsync(string catId);
    }
}