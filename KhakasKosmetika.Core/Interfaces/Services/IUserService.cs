using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> PartialyCreateUserAsync();
        Task<User> RegisterExistingUserAsync(Guid id, string userName, string passwordHash, string email, string phoneNumber);
        Task<User> RegisterNewUserAsync(string userName, string passwordHash, string email, string phoneNumber);
    }
}