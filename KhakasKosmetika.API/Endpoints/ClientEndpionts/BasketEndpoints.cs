using KhakasKosmetika.API.Requests;
using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KhakasKosmetika.API.Endpoints.ClientEndpionts
{
    public static class BasketEndpoints
    {
        public static IEndpointRouteBuilder MapBasketEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("addProductInBasket", AddProductinBasketAsync).AllowAnonymous();
            app.MapGet("getBasketByUserId", GetBasketByUserId).AllowAnonymous();
            app.MapDelete("deleteProductFromBasket", DeleteProductFromBasket).AllowAnonymous();
            app.MapDelete("clearBasketByUserId", ClearBasketByUserId).AllowAnonymous();
            return app;
        }
        private static async Task<IResult> AddProductinBasketAsync(
            IBasketService basketService,
            [FromBody] ProductRequest request
            )
        {
            var res = await basketService.AddProductToBasketAsync(request.userId, request.productId);
            return Results.Ok(res);
        }



        private static async Task<IResult> GetBasketByUserId(
            IBasketService basketService,
            IProductsService productsService,
            string userId
            //[FromBody] FavouriteProductRequest request
            )
        {
            var favProducts = await productsService.GetFavouriteProductsAsync(userId);
            var products = await basketService.GetBasketByUserIdAsync(userId);
            IEnumerable<ProductResponce> result = products.Select(c => new ProductResponce(c.Item1.Id, c.Item1.Name, c.Item1.PriceFull, "Описание отсутствует", c.Item1.PhotoLink, 1, favProducts.FirstOrDefault(o => c.Item1.Id == o.Id) != null, true, c.Item2));
            return Results.Ok(result);

        }

        private static async Task<IResult> DeleteProductFromBasket(
            IBasketService basketService,
            [FromBody] ProductRequest request
            )
        {
            var res = await basketService.RemoveSingleProductAsync(request.userId, request.productId);
            return Results.Ok(res);
        }
        private static async Task<IResult> ClearBasketByUserId(
            IBasketService basketService,
            string userId
            )
        {
            var res = await basketService.ClearBasketByUserIdAsync(userId);
            return Results.Ok(res);
        }
    }
}
