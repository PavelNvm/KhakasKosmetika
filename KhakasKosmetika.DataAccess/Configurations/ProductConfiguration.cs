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
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Art).IsRequired();
            builder.Property(b => b.Code).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.PriceLow).IsRequired();
            builder.Property(b => b.PriceFull).IsRequired();
            builder.Property(b => b.Rests).IsRequired();
            builder.Property(b => b.AmountOfCategories).IsRequired();
            builder.Property(b => b.Categories).IsRequired();
            builder.Property(b => b.PhotoLink).IsRequired();

            builder.Property(b => b.Lenght);
            builder.Property(b => b.Width);
            builder.Property(b => b.Height);
            builder.Property(b => b.Diameter);
            builder.Property(b => b.Volume);
            builder.Property(b => b.Weight);
            builder.Property(b => b.Version);
            builder.Property(b => b.DeletionMarker);

        }
    }
}
