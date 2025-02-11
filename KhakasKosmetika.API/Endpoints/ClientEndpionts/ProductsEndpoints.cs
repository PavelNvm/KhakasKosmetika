using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using System.Linq;

namespace KhakasKosmetika.API.Endpoints.ClientEndpionts
{
    public static class ProductsEndpoints
    {
        public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
        {

            //app.MapGet("getProducts", GetProducts).AllowAnonymous();


            app.MapGet("getProductsByCategoryId", GetProductsByCategoryId).AllowAnonymous();
            app.MapGet("getSingleProductById", GetSingleProductById).AllowAnonymous();
            return app;
        }

        private static async Task<IResult> GetProductsByCategoryId(
            IProductsService productsService,
            IBasketService basketService,
            string categoryId,
            string userId,
            int amount = 10
            )
        {
            var Products = await productsService.GetProductsByCategoryIdAsync(categoryId);
            var favProds = await productsService.GetFavouriteProductsAsync(userId);
            var basket = await basketService.GetBasketByUserIdAsync(userId);


            IEnumerable<ProductResponce> result = Products.Select(c =>
            new ProductResponce(c.Id, c.Name, c.PriceFull, "Описание отсутствует", c.PhotoLink, 1,
            favProds.FirstOrDefault(o => o.Id == c.Id) != null,
            basket.FirstOrDefault(o => o.Item1.Id == c.Id).Item1 != null,
            basket.FirstOrDefault(o => o.Item1.Id == c.Id).Item2));
            return Results.Ok(result);
        }
        private static async Task<IResult> GetSingleProductById(
            IProductsService productsService,
            IBasketService basketService,
            string userId,
            string Id
            )
        {
            var product = await productsService.GetSingleProductByIdAsync(Id);
            var basket = await basketService.GetBasketByUserIdAsync(userId);
            (Product, int) prodInBasket = basket.FirstOrDefault(o => o.Item1.Id == product.Id);
            ProductResponce result = new ProductResponce(product.Id, product.Name, product.PriceFull, "Описание отсутствует", product.PhotoLink, 1,
                (await productsService.GetFavouriteProductsAsync(userId)).FirstOrDefault(o => o.Id == product.Id) != null,
                prodInBasket.Item1 != null,
                prodInBasket.Item2);
            return Results.Ok(result);
        }


        private static async Task<IResult> GetProducts(
            IXMLReaderService ReaderService,
            int amount = 10
            )
        {
            var Products = await ReaderService.ReadProducts();
            IEnumerable<ProductResponce> result = Products.Select(c => new ProductResponce(c.Id, c.Name, c.PriceFull, "Описание отсутствует", c.PhotoLink, 1, false, false, 0));
            return Results.Ok(result);
        }
        private static List<string> Unglue(string gluedString)
        {
            List<string> res = new List<string>();
            foreach (var id in gluedString.Split(';'))
                res.Add(id);
            res.RemoveAt(res.Count - 1);
            return res;
        }
    }
}
