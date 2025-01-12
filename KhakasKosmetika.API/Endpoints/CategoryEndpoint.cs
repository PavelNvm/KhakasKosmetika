using KhakasKosmetika.API.Responses;
using KhakasKosmetika.Core.Interfaces.Services;
using KhakasKosmetika.Core.Models;
using System.Linq;

namespace KhakasKosmetika.API.Endpoints
{
    public static class CategoryEndpoint
    {
        public static IEndpointRouteBuilder MapCategoriesEndpoints(this IEndpointRouteBuilder app)
        {

            //app.MapGet("getCategoriesOld", GetCategoriesOld).AllowAnonymous();
            //app.MapGet("getAllCategories", GetAllCategories).AllowAnonymous();
            //app.MapGet("getCategoriesById", GetCategoriesById).AllowAnonymous();


            app.MapGet("getFilledCategoriesById", GetFilledCategoriesById).AllowAnonymous();
            app.MapGet("getCategoryNameById", GetCategoryNameById).AllowAnonymous();
            app.MapGet("getCategoriesDepthZero", GetCategoriesDepthZero).AllowAnonymous();
            return app;
        }
        private static async Task<IResult> GetCategoryNameById(
            ICategoriesService categoriesService,
            string id
            )
        {
            string result = await categoriesService.GetCategoryNameById( id );
            return Results.Ok(result);
        }
        private static async Task<IResult> GetCategoriesDepthZero(
            ICategoriesService categoriesService
            )
        {
            var Categories = await categoriesService.GetCategoriesDepthZero();
            List<CategoryResponse> result = new List<CategoryResponse>();
            foreach (Category cat in Categories.Where(o => o.Depth == 0).ToList())
            {
                result.Add(new CategoryResponse(cat.Id, cat.Name, cat.Depth));
            }
            return Results.Ok(result);
        }
        private static async Task<IResult> GetFilledCategoriesById(
            ICategoriesService categoriesService,
            string superGroupId
            )
        {
            var Categories = await categoriesService.GetFilledCategoriesById(superGroupId);
            List<CategoryResponse> result = new List<CategoryResponse>();
            foreach (var cat in Categories)
            {
                result.Add(new CategoryResponse(cat.Id, cat.Name, cat.Depth));
            }
            return Results.Ok(result);
        }

        private static async Task<IResult> GetCategoriesById(
            IXMLReaderService ReaderService,
            string superGroupId
            )
        {
            var Categories = await ReaderService.ReadCategories();
            List<CategoryResponse> result = new List<CategoryResponse>();
            foreach (Category cat in Categories.Where(o => o.SupergroupId == superGroupId).ToList())
            {
                result.Add(new CategoryResponse(cat.Id, cat.Name, cat.Depth                
            ));
            }
            return Results.Ok(result);
        }

        

        private static async Task<IResult> GetAllCategories(
            IXMLReaderService ReaderService
            )
        {
            var Categories = await ReaderService.ReadCategories();
            List<CategoryResponse> result = new List<CategoryResponse>();
            foreach (Category cat in Categories)
            {
                result.Add(new CategoryResponse(cat.Id, cat.Name, cat.Depth));
            }
            return Results.Ok(result);
        }

        private static async Task<IResult> GetCategoriesOld(
            IXMLReaderService ReaderService,
            int amount = 10
            )
        {
            var Categories = await ReaderService.ReadCategories();
            List<CategoryResponseOld> result = new List<CategoryResponseOld>();
            foreach (Category cat in Categories.Where(o => o.Depth == 0).ToList())
            {
                result.Add(new CategoryResponseOld(cat.Id, cat.Name, cat.Depth,
            GetSubcats(Categories.Where(o => o.SupergroupId.Contains(cat.Id)).ToList(), Categories)
            ));
            }
            return Results.Ok(result);
        }
        private static List<CategoryResponseOld> GetSubcats(List<Category> list, List<Category> wholeList)
        {
            List<CategoryResponseOld> result = new List<CategoryResponseOld>();
            foreach (Category c in list) 
            {
                if (c.Depth < 2)
                    result.Add(new CategoryResponseOld(c.Id, c.Name, c.Depth,
                    GetSubcats(wholeList.Where(o => o.SupergroupId == c.Id).ToList(), wholeList)));
                else
                {
                    result.Add(new CategoryResponseOld(c.Id, c.Name, c.Depth, []));
                }
            }
            return result;
        }
    }
}
