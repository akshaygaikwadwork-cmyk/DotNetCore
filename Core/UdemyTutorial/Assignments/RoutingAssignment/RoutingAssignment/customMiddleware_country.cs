using System.Runtime.CompilerServices;

namespace RoutingAssignment
{
    public class customMiddleware_country
    {
        private readonly RequestDelegate _next;
        public customMiddleware_country(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Dictionary<int, string> country = new Dictionary<int, string>();
            country.Add(1, "United States");
            country.Add(2, "Canada");
            country.Add(3, "United Kingdom");
            country.Add(4, "India");
            country.Add(5, "Japan");
            await _next(context);

            if (context.Request.Method == "GET")
            {
                if (context.Request.Path == "/countries")
                {
                    foreach (KeyValuePair<int, string> kvp in country)
                    {
                        await context.Response.WriteAsync($"{kvp.Key} , {kvp.Value} \n");
                    }
                }

                if (context.Request.Path == "/countries/{countryID}=int")
                {
                    int key = Convert.ToInt32(context.Request.Query["countryID"]);
                    if (key > 100)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("The CountryID should be between 1 and 100.");
                    }
                    if (key >= 1 && key <= 5)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync("No Country");
                    }
                    foreach (KeyValuePair<int, string> kvp in country)
                    {
                        if (kvp.Key == key)
                        {
                            await context.Response.WriteAsync($"{kvp.Key} , {kvp.Value} \n");
                            break;
                        }
                    }
                }

            }

        }

    }

    public static class MiddlewareExtention
    {
        public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<customMiddleware_country>();
        }
    }
}
