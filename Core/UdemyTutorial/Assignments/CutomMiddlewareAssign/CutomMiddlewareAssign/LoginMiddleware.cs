using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace CutomMiddlewareAssign
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Read response body as stream
            StreamReader reader = new StreamReader(context.Request.Body);
            string body = await reader.ReadToEndAsync();

            //Parse the request body from string into Dictionary
            Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);

            if (context.Request.Method == "POST" && context.Request.Path == "/")
            {
                string? email = null, password = null;

                //read 'firstNumber' if submitted in the request body
                if (queryDict.ContainsKey("email"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                }

                //read 'secondNumber' if submitted in the request body
                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'\n");
                }

                //if both email and password are submitted in the request
                if (string.IsNullOrEmpty(email) == false && string.IsNullOrEmpty(password) == false)
                {
                    //valid email and password as per the requirement specification
                    string validEmail = "admin@example.com", validPassword = "admin1234";
                    bool isValidLogin;

                    //if email and password are valid
                    if (email == validEmail && password == validPassword)
                    {
                        isValidLogin = true;
                    }
                    else
                    {
                        isValidLogin = false;
                    }

                    //send response
                    if (isValidLogin)
                    {
                        await context.Response.WriteAsync("Successful login\n");
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid login\n");
                    }

                } //end of "if !string.IsNullOrEmpty"


            } //end of "if method == POST"

            //else, invoke subsequent middleware (if any)
            else
            {
                await _next(context);
            }

        }
    }

    public static class LoginMiddlewareExtention
    {
        public static IApplicationBuilder UseMiddlewareExtention(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoginMiddleware>();
        }
    }
}
