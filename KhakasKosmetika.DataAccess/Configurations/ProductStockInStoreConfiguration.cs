using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhakasKosmetika.DataAccess.Configurations
{
    public class ProductStockInStoreConfiguration : IEntityTypeConfiguration<ProductStockInStoreEntity>
    {
        public void Configure(EntityTypeBuilder<ProductStockInStoreEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.StoreId).IsRequired();
            builder.Property(b => b.ProductId).IsRequired();
            builder.Property(b => b.Amount).IsRequired();
        }
    }
}
