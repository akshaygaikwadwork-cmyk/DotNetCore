namespace CustomMiddlewareExample
{
    public class ResponseHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public ResponseHeaderMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            await Console.Out.WriteLineAsync("Shubham");

            // Call the next middleware in the pipeline
            await _next(context);

            // Add a custom header to the response
            _logger.LogInformation("2nd middleware response executed");
        }
    }
}
