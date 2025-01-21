using KhakasKosmetika.Core.Models;

namespace KhakasKosmetika.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> PartialyCreateUserAsync();
        Task<User> RegisterExistingUser(Guid id, string userName, string passwordHash, string email, string phoneNumber);
        Task<User> RegisterNewUser(string userName, string passwordHash, string email, string phoneNumber);
    }
}