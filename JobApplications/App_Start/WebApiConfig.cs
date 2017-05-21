using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JobApplications {
   public static class WebApiConfig {
      public static void Register(HttpConfiguration config) {
         var settings = config.Formatters.JsonFormatter.SerializerSettings;
         settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         settings.Formatting = Formatting.Indented;

         // Self referencing loop detected with type 'System.Data.Entity.DynamicProxies.
         settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

         // Seems to default to XML formatter for responses. But the XML formatter craps out for some reason.
         // So remove this formatter so that it uses the JSON formatter.
         config.Formatters.Remove(config.Formatters.XmlFormatter);

         // Web API configuration and services

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
