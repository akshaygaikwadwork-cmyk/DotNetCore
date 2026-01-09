namespace CustomMiddleware.CustomeMiddleware
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
}
