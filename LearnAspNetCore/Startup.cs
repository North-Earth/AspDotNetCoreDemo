using System.Threading.Tasks;
using LearnAspNetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LearnAspNetCore
{
    public class Startup
    {
        private int x = 5;
        private int y = 2;
        private int z = 0;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<TimeService>();
            services.AddTransient<MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, TimeService timeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<MessageMiddleware>();

            //app.Run(async (context) =>
            //{
            //    var sender = context.RequestServices.GetService<MessageService>(); //Вернёт null
            //    //var sender = context.RequestServices.GetRequiredService<MessageService>(); //Вернёт Exeption
            //    await context.Response.WriteAsync($"{sender?.SendMessage()} " +
            //        $"Time: {timeService.GetTime()}");
            //});

            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("HelloPage.html");

            //app.UseDefaultFiles(options); //default.html index.html
            //app.UseStaticFiles();

            //app.UseMiddleware<ErrorHanlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();

            //app.UseToken("5555");

            //app.Map("/home", (home) =>
            //{
            //    home.Map("/index", (appBuilder) =>
            //    {
            //        appBuilder.Run(async (contex)
            //            => await contex.Response.WriteAsync("<h2>Home Page</h2>"));
            //    });
            //    home.Map("/about", About);
            //});

            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    await next();
            //    z = z * 5;
            //    await Handle(context);
            //});

            //app.Run(async (context) =>
            //{
            //    z = z * 2;
            //    await Task.FromResult(0);
            //});
        }

        private void About(IApplicationBuilder appBuilder)
        {
            appBuilder.Run(async (contex)
                => await contex.Response.WriteAsync("<h2>About</h2>"));
        }

        private async Task Handle(HttpContext context)
        {
            string host = context.Request.Host.Value;
            string path = context.Request.Path;
            string query = context.Request.QueryString.Value;

            context.Response.ContentType = "text/html;charset=utf-8";

            await context.Response.WriteAsync($"<h3>Хост: {host}</h3>" +
                $"<h3>Пусть запроса: {path}</h3>" +
                $"<h3>Параметры строки запроса: {query}</h3>" +
                $"z = {z}");
        }
    }
}
