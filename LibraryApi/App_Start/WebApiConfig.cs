using Microsoft.Web.Http;

using Newtonsoft.Json.Serialization;

using System.Web.Http;

namespace LibraryApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = 
                    new CamelCasePropertyNamesContractResolver();

            config.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 1);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes
                .MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
