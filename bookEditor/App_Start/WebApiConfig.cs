using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace bookEditor
{
    public static class WebApiConfig
    {
        public static IContractResolver CamelCasePropertyNameContractResolver { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            var jsonFormater = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormater.SerializerSettings.ContractResolver = CamelCasePropertyNameContractResolver;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "bookEditAPI",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
