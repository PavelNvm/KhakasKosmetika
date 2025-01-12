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
    public class ProductInBasketConfiguration : IEntityTypeConfiguration<ProductInBasketEntity>
    {
        public void Configure(EntityTypeBuilder<ProductInBasketEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Amount).IsRequired();
        }
    }
}
