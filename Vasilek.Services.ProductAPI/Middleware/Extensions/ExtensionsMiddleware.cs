using Vasilek.Services.ProductAPI.Middleware.CustomException;

namespace Vasilek.Services.ProductAPI.Middleware.Extensions
{
    public static class ExtensionsMiddleware
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
