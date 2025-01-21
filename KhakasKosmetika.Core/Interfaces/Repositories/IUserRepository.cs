using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<Guid> DeleteUserAsync(Guid id);
        Task<User> GetUserAsync(Guid id);
        Task<Guid> PartialyCreateUserAsync();
        Task<User> UpdateUserAsync(User user);
    }
}