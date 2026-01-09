namespace CustomMiddlewareExampleFinal
{
    public class RequestClass
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestClass> _logger;

        public RequestClass(ILogger<RequestClass> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request details
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Call the next middleware in the pipeline
            await _next(context);

            // Log response details
            _logger.LogInformation("Finished handling request");
        }

    }
}
