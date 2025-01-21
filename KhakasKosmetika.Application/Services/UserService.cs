using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> PartialyCreateUserAsync()
        {
            var id = await _userRepository.PartialyCreateUserAsync();
            return id;
        }
        public async Task<User> RegisterExistingUser(
            Guid id,
            string userName,
            string passwordHash,
            string email,
            string phoneNumber
            )
        {
            var user = await _userRepository.UpdateUserAsync(
                User.Create(
                    id,
                    userName,
                    passwordHash,
                    email,
                    phoneNumber,
                    0,
                    DateOnly.FromDateTime(DateTime.Now)
                ));
            return user;
        }
        public async Task<User> RegisterNewUser(
            string userName,
            string passwordHash,
            string email,
            string phoneNumber)
        {
            var user = await _userRepository.CreateUserAsync(
                User.Create(
                    Guid.NewGuid(),
                    userName,
                    passwordHash,
                    email,
                    phoneNumber,
                    0,
                    DateOnly.FromDateTime(DateTime.Now)));
            return user;

        }





    }
}
