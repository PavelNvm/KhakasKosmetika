using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.Core.Models
{
    public class User
    {
        public Guid Id { get; }
        public string UserName { get; }
        public string PasswordHash { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public int BonusBalance { get; }
        public DateOnly RegistrationDate { get; }
        public static User Create(
            Guid id,
            string userName,
            string passwordHash,
            string email,
            string phoneNumber,
            int bonusBalance,
            DateOnly registrationDate)
        {
            return new User(
            id,
            userName,
            passwordHash,
            email,
            phoneNumber,
            bonusBalance,
            registrationDate);
        }
        private User(
            Guid id,
            string userName,
            string passwordHash,
            string email,
            string phoneNumber,
            int bonusBalance,
            DateOnly registrationDate
            )
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            PhoneNumber = phoneNumber;
            BonusBalance = bonusBalance;
            RegistrationDate = registrationDate;
        }

    }
}
