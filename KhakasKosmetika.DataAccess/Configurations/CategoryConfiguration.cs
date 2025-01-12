using KhakasKosmetika.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KhakasKosmetika.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b=>b.SupergroupId).IsRequired();
            builder.Property(b=>b.Name).IsRequired();
            builder.Property(b=>b.Version);
            builder.Property(b=>b.DeletionMarker);
            builder.Property(b=>b.Depth).IsRequired();
        }
    }
}
