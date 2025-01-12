using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
