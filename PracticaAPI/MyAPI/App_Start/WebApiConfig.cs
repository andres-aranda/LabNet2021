using System.Web.Http;
using System.Web.Http.Cors;

namespace MyAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var CORS = new EnableCorsAttribute(origins: "*", headers: "*", methods: "*");
            config.EnableCors(CORS);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
