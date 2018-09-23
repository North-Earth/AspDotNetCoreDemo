using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LearnAspNetCore
{
    public class ErrorHanlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHanlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Access Denied");
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Not Found");
        }
    }
}
