using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using RevCode_API.ActionFilters;
namespace RevCode_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var corsAttr = new EnableCorsAttribute("*", "*", "*");

            var corsAttr = new EnableCorsAttribute("*",
                                          "Origin, Content-Type, Accept",
                                          "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(corsAttr);
            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.MapHttpAttributeRoutes();
         //   config.Filters.Add(new LoggingFilterAttribute());
            config.Filters.Add(new GlobalExceptionAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "RevCode_API/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
