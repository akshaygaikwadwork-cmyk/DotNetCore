using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    //used StringValues instead of string because in case of age = 20; then age = 30; then it will take age both values but if you used string then it will not take
    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (queryDict.ContainsKey("FirstName"))
    {
        string FName = queryDict["FirstName"][0];
        await context.Response.WriteAsync(FName);
        //OR
        //foreach (var item in queryDict["FirstName"])
        //{

        //}

    }
});
app.Run();
