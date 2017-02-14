using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Middleware;

namespace WebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //UseRequestTimer Middleware can be used without options
            //app.UseRequestTimer();

            app.UseRequestTimer(new RequestTimerOptions
            {
                Format = (context, elapsed) => $"Request {context.Request.Path} took {elapsed} ms"
            });

            app.Run(async (context) => 
                await context.Response.WriteAsync("Hello World")
            );
        }
    }
}
