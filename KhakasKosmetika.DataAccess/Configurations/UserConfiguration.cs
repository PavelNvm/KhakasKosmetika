using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Configurations
{
    
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserName).IsRequired();
            builder.Property(b => b.PasswordHash).IsRequired();
            builder.Property(b => b.Email).IsRequired();
            builder.Property(b => b.PhoneNumber).IsRequired();
            builder.Property(b => b.BonusBalance).IsRequired();
            builder.Property(b => b.RegistrationDate).IsRequired();
        }
    }
}
