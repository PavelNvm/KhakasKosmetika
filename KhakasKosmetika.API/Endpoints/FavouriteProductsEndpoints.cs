using KhakasKosmetika.API.Requests;
using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Application.Services;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KhakasKosmetika.API.Endpoints
{
    public static class FavouriteProductsEndpoints
    {
        public static IEndpointRouteBuilder MapFavouriteProductsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("addFavouriteProduct", AddFavouriteProduct).AllowAnonymous();
            app.MapGet("getFavouriteProducts", GetFavouriteProducts).AllowAnonymous();
            app.MapDelete("deleteFavouriteProduct", DeleteFavouriteProduct).AllowAnonymous();



            return app;
        }
        private static async Task<IResult> AddFavouriteProduct(
            IProductsService productsService,
            [FromBody] FavouriteProductRequest request
            )
        {
            var res = await productsService.AddFavouriteProductAsync(request.userId, request.productId);
            return Results.Ok(res);
        }



        private static async Task<IResult> GetFavouriteProducts(
            IProductsService productsService,
            string userId
            //[FromBody] FavouriteProductRequest request
            )
        {
            var Products = await productsService.GetFavouriteProductsAsync(userId);
            IEnumerable<ProductResponce> result = Products.Select(c => new ProductResponce(c.Id, c.Name, c.PriceFull, "Описание отсутствует", c.PhotoLink));
            return Results.Ok(result);

        }

        private static async Task<IResult> DeleteFavouriteProduct(
            IProductsService productsService,
            [FromBody] FavouriteProductRequest request,
            HttpContext context)
        {

            var cookies = context.Request.Cookies;
            if (!cookies.ContainsKey("smewapiq")) //New user
            {
                return Results.Ok();

            }
            else // Existing user
            {
                string userId;
                cookies.TryGetValue("userId", out userId);
                var res = await productsService.DeleteSingleEntryAsync(userId, request.productId);
                return Results.Ok();
            }
        }
    }
}
