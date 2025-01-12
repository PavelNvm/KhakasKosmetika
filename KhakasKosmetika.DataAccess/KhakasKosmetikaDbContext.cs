using KhakasKosmetika.Core.Models;
using KhakasKosmetika.DataAccess.Configurations;
using KhakasKosmetika.DataAccess.Entities;
using KhakasKosmetika.XML_Importer;
using Microsoft.EntityFrameworkCore;

namespace KhakasKosmetika.DataAccess
{
    public class KhakasKosmetikaDbContext:DbContext
    {
        public KhakasKosmetikaDbContext(DbContextOptions<KhakasKosmetikaDbContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new FavouriteProductConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductInBasketConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductStockInStoreConfiguration());
            //modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            //modelBuilder.ApplyConfiguration(new StoreConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());


            //DataReaderService dataReaderService = new DataReaderService();   

            //modelBuilder.Entity<CategoryEntity>().HasData(dataReaderService.ReadCategories().Result.Select(category=>new CategoryEntity() 
            //{
            //    Id = category.Id,
            //    SupergroupId = category.SupergroupId,
            //    Name = category.Name,
            //    Version = category.Version,
            //    DeletionMarker = category.DeletionMarker,
            //    Depth = category.Depth
            //}));

            //modelBuilder.Entity<ProductEntity>().HasData(dataReaderService.ReadProducts().Result.Select(product => new ProductEntity()
            //{
            //    Id = product.Id,
            //    Art = product.Art,
            //    Code = product.Code,
            //    Lenght = product.Lenght,
            //    Width = product.Width,
            //    Height = product.Height,
            //    Diameter = product.Diameter,
            //    Volume = product.Volume,
            //    Weight = product.Weight,
            //    Name = product.Name,
            //    PriceLow = product.PriceLow,
            //    PriceFull = product.PriceFull,
            //    Rests = product.Rests,
            //    Version = product.Version,
            //    DeletionMarker = product.DeletionMarker,
            //    AmountOfCategories = product.AmountOfCategories,
            //    Categories = product.Categories,
            //    PhotoLink = product.PhotoLink
            //}));


        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<FavouriteProductEntity> FavouriteProducts { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductInBasketEntity> ProductsInBasket { get; set; }
        public DbSet<ProductStockInStoreEntity> ProductStockInStores { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
