using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LearnAspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseWebRoot("static")
                .UseStartup<Startup>();
    }
}
