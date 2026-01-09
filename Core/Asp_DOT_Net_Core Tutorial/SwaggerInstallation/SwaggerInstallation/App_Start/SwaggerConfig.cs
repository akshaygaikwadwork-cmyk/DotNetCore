using System.Web.Http;
using WebActivatorEx;
using SwaggerInstallation;
using Swashbuckle.Application;
using System.Web.Mvc;
using System.Web.UI.WebControls;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerInstallation
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "This is First Web API with swagger installation");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}