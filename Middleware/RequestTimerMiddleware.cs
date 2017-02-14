using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace WebApplication.Middleware
{
    public class RequestTimerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimerMiddleware> _logger;

        public RequestTimerMiddleware(RequestDelegate next, ILogger<RequestTimerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var timer = new Stopwatch();
            timer.Start();

            await _next(context);
            
            timer.Stop();
            _logger.LogInformation($"Request to {context.Request.Path} took {timer.ElapsedMilliseconds} ms");
        }
    }
}