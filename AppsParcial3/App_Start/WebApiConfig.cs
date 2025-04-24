using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AppsParcial3.Clases;

namespace AppsParcial3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MessageHandlers.Add(new TokenValidationHandler());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
