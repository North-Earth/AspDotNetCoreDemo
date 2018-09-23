using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LearnAspNetCore
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            if (path == "/" || path == "/index")
                await context.Response.WriteAsync("Home Page");
            else if (path == "/about")
                await context.Response.WriteAsync("About");
            else
                context.Response.StatusCode = 404;
        }
    }
}
