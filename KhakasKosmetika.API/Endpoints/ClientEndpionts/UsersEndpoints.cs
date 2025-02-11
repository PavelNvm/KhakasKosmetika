using KhakasKosmetika.API.Requests;
using KhakasKosmetika.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace KhakasKosmetika.API.Endpoints.ClientEndpionts
{
    public static class UsersEndpoints
    {

        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("partialyCreateUser", PartialyCreateUser).AllowAnonymous();



            return app;
        }
        private static async Task<IResult> PartialyCreateUser(
            IUserService userService
            )
        {
            var res = await userService.PartialyCreateUserAsync();
            return Results.Ok(res.ToString());
        }
    }
}
