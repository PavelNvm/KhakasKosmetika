using KhakasKosmetika.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;


namespace KhakasKosmetika.API.Endpoints
{
    public static class ImagesEndpoints
    {
        public static IEndpointRouteBuilder MapImagesEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("getImageByCategoryId", GetImageByCategoryId).AllowAnonymous();

            return app;
        }



        private static async Task<IResult> GetImageByCategoryId(
            IImageService imageService,
            string categoryId
            )
        {
            
            var res = await imageService.GetImagebyCategoryId(categoryId);
            if (res != null)
                return Results.File(res, "image/jpg");
            else
                return Results.Ok(); 
        }
        



    }
}
