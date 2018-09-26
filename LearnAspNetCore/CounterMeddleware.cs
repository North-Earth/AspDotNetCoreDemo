using System.Threading.Tasks;
using LearnAspNetCore.Services;
using Microsoft.AspNetCore.Http;

namespace LearnAspNetCore
{
    public class CounterMeddleware
    {
        private int i = 0;

        public CounterMeddleware(RequestDelegate next)
        {

        }

        public async Task InvokeAsync(HttpContext context, ICounter counter,
            CounterService counterService)
        {
            i++;
            await context.Response.WriteAsync($"Request: {i} ICounter: {counter.Value} " +
                $"CounterService: {counterService.Counter.Value}");
        }
    }
}
