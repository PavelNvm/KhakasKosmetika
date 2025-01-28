using KhakasKosmetika.API.Extentions;
using KhakasKosmetika.Application.Services;
using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.DataAccess;
using KhakasKosmetika.DataAccess.Repositories;
using KhakasKosmetika.XML_Importer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("rnd",
//                      policy =>
//                      {
//                          policy.AllowAnyOrigin();
//                          policy.AllowAnyHeader();
//                          policy.AllowAnyMethod();
//                          policy.WithOrigins("http://localhost:8081");
//                      });
//});
services.AddDbContext<KhakasKosmetikaDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString(nameof(KhakasKosmetikaDbContext)));
});
services.AddScoped<IUserRepository,UserRepository>();
services.AddScoped<IUserService,UserService>();
services.AddScoped<IBasketService,BasketService>();
services.AddScoped<IProductsInBasketRepository,ProductsInBasketRepository>();
services.AddScoped<IFavouriteProductsRepository,FavouriteProductsRepository>();
services.AddScoped<ICategoryRepository, CategoryRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ICategoriesService,CategoriesService>();
services.AddScoped<IProductsService,ProductsService>();
services.AddScoped<IImageRepository,ImageRepository>();
services.AddScoped<IImageService, ImageService>();

services.AddScoped<IXMLReaderService, DataReaderService>();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.AddMappedEndpoints();
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});
app.Run();
