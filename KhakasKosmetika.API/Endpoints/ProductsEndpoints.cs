using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Core.Interfaces.Repositories;
using KhakasKosmetika.Core.Interfaces.Services;
using System.Linq;

namespace KhakasKosmetika.API.Endpoints
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
            string categoryId,
            string userId,
            int amount = 10
            )
        {
            var Products = await productsService.GetProductsByCategoryIdAsync(categoryId);
            IEnumerable<ProductResponce> result = Products.Select(c => new ProductResponce(c.Id, c.Name, c.PriceFull, "Описание отсутствует", c.PhotoLink,1,false,false,0));
            var favProds = await productsService.GetFavouriteProductsAsync(userId);
            foreach (var product in favProds)
            {
                var temp = result.FirstOrDefault(o => o.id == product.Id);
                if (temp != null)
                {
                    temp = temp with { isFavourite = true };
                }
            }
            return Results.Ok(result);
        }
        private static async Task<IResult> GetSingleProductById(
            IProductsService productsService,
            string userId,
            string Id
            )
        {
            var Product = await productsService.GetSingleProductByIdAsync(Id);
            bool isFav=false;
            var a = await productsService.GetFavouriteProductsAsync(userId);
            if (a != null)
            {
                isFav = true;
            }
            ProductResponce result = new ProductResponce(Product.Id, Product.Name, Product.PriceFull, "Описание отсутствует", Product.PhotoLink, 1, isFav, false, 0);
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
            foreach(var id in gluedString.Split(';'))
                res.Add(id);
            res.RemoveAt(res.Count-1);
            return res;
        }
    }
}
