namespace CustomeMiddlewareExtensions.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nCustom Middlware start");
            await next(context);
            await context.Response.WriteAsync("\nCustom Middlware end");
        }
    }

    public static class CustomMiddlewareExtention1
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
