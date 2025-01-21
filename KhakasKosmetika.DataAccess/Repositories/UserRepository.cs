using KhakasKosmetika.Core.Models;
using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KhakasKosmetika.Core.Interfaces.Repositories;

namespace KhakasKosmetika.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KhakasKosmetikaDbContext _context;
        public UserRepository(KhakasKosmetikaDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> PartialyCreateUserAsync()
        {
            UserEntity user = new UserEntity() { Id = Guid.NewGuid() };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }


        public async Task<User> CreateUserAsync(User user)
        {
            UserEntity userEntity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BonusBalance = user.BonusBalance,
                RegistrationDate = user.RegistrationDate
            };
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return userEntity.ToUser();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var oldUser = await _context.Users.FirstOrDefaultAsync(o => o.Id == user.Id);
            oldUser.UserName = user.UserName;
            oldUser.PasswordHash = user.PasswordHash;
            oldUser.Email = user.Email;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.BonusBalance = user.BonusBalance;
            oldUser.RegistrationDate = user.RegistrationDate;

            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<User> GetUserAsync(Guid id)
        {
            var res = await _context.Users.Where(u => u.Id == id).Select(u => User.Create(
                u.Id,
                u.UserName,
                u.PasswordHash,
                u.Email,
                u.PhoneNumber,
                u.BonusBalance,
                u.RegistrationDate)).FirstOrDefaultAsync();
            return res;
        }
        public async Task<Guid> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

    }
}
