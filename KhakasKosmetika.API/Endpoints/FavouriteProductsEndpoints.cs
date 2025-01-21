using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Application.Services;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KhakasKosmetika.API.Endpoints
{
    public static class FavouriteProductsEndpoints
    {
        public static IEndpointRouteBuilder MapFavouriteProductsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("addFavouriteProduct", AddFavouriteProduct).AllowAnonymous();
            app.MapGet("getFavouriteProducts", GetFavouriteProducts).AllowAnonymous();



            return app;
        }
        private static async Task<IResult> AddFavouriteProduct(
            IProductsService productsService,
            IUserService userService,
            string productId,
            HttpContext context)
        {
            var cookies = context.Request.Cookies;
            if (!cookies.ContainsKey("smewapiq") ) //New user
            {
                context.Response.Cookies.Append("smewapiq", "true");
                var userId = await userService.PartialyCreateUserAsync();
                await productsService.AddFavouriteProductAsync(userId.ToString(), productId);
                context.Response.Cookies.Append("userId", userId.ToString());
                return Results.Ok();
            }
            else // Existing user
            {
                string userId;
                cookies.TryGetValue("userId", out userId);
                await productsService.AddFavouriteProductAsync(userId.ToString(), productId);
                return Results.Ok();
            }
        }



        private static async Task<IResult> GetFavouriteProducts(
            IProductsService productsService,
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
                var Products = await productsService.GetFavouriteProductsAsync(userId);
                IEnumerable<ProductResponce> result = Products.Select(c => new ProductResponce(c.Id, c.Name, c.PriceFull, "Описание отсутствует", c.PhotoLink));
                return Results.Ok(result);
            }
        }

        private static async Task<IResult> GetMessage(
            IProductsService productsService,
            ICategoriesService categoriesService,
            HttpContext context)
        {

            context.Response.Cookies.Append("userInfo", "123");
            string mes = "succes";

            return Results.Ok(mes);
        }

        private static async Task<IResult> GetInfo(
            IProductsService productsService,
            ICategoriesService categoriesService,
            HttpContext context)
        {
            var res = context.Request.Cookies.FirstOrDefault(o=>o.Key=="userInfo").Value.ToString();
            string mes = "succes";

            return Results.Ok(res);
        }





    }
}
