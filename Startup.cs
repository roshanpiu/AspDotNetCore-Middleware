using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;

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

            app.Use(next => async context =>
            {
                var timer = new Stopwatch();
                timer.Start();
                await next(context);
                timer.Stop();
                var logger = loggerFactory.CreateLogger("Request Timer");
                logger.LogInformation($"Request to {context.Request.Path} took {timer.ElapsedMilliseconds} ms");
            });

            app.Run(async (context) => 
                await context.Response.WriteAsync("Hello World")
            );
        }
    }
}
