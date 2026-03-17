using System.Web.Http;
using Swashbuckle.Application;
using WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SampleProject API");
                    c.PrettyPrint();
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("SampleProject API");
                });
        }
    }
}
