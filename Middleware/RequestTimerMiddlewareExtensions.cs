using WebApplication.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class RequestTimerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimer(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestTimerMiddleware>();
        }
    }
}