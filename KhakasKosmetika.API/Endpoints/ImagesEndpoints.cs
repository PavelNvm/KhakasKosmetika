using KhakasKosmetika.Core.Interfaces.Services;


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
            string path = @$"Images\\{categoryId}.png";
            var filePath = Path.Combine("..", "Images", $"{categoryId}.png");
            var res = await imageService.GetImagebyCategoryId(categoryId);

            return Results.File(res, "image/png");
        }
        



    }
}
