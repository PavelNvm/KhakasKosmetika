using KhakasKosmetika.API.Endpoints;

namespace KhakasKosmetika.API.Extentions
{
    public static class ApiExtentions
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapProductsEndpoints();
            app.MapCategoriesEndpoints();
            app.MapImagesEndpoints();
            app.MapFavouriteProductsEndpoints();
            app.MapUsersEndpoints();
            app.MapBasketEndpoints();


        }
    }
}
