using BY.Store.Shared.Params;

namespace BY.Store.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AppStartUpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationParams _applicationParams;
        public AppStartUpMiddleware(RequestDelegate next, IApplicationParams applicationParams)
        {
            _next = next;
            _applicationParams = applicationParams;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (!_applicationParams.IsAppStarted)
            {
                _applicationParams.CurrentCustomerId = 1;
                _applicationParams.IsAppStarted = true;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AppStartUpMiddlewareExtensions
    {
        public static IApplicationBuilder UseAppStartUpMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppStartUpMiddleware>();
        }
    }
}
