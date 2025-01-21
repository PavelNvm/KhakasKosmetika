using KhakasKosmetika.Core.Models;
namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface IFavouriteProductsRepository
    {
        Task<string> CreateEntryAsync(Guid userId, string productId);
        Task<string> DeleteEntriesByProductId(string productId);
        Task<string> DeleteEntriesByUserId(Guid userId);
        Task<string> DeleteSingleEntry(Guid userId, string productId);
        Task<List<FavouriteProduct>> GetEntries(Guid userId);
    }
}