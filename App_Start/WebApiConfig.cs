
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GenerateSingleApi3",
                routeTemplate: "api/{controller}/{id1}/{id2}/{id3}",
                defaults: new { id1 = RouteParameter.Optional, id2 = RouteParameter.Optional, id3 = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SingleApiSolve",
                routeTemplate: "api/{controller}/{maze}",
                defaults: new { maze = RouteParameter.Optional }
            );

          
            config.Routes.MapHttpRoute(
            name: "GenerateSingleApi",
            routeTemplate: "api/{controller}"
            );
            config.Routes.MapHttpRoute(
              name: "loginUser",
               routeTemplate: "api/{controller}/{name}/{password}",
               defaults: new { controller = "Users", name = RouteParameter.Optional  , password= RouteParameter.Optional }
           );


            // Web API routes
            /* config.MapHttpAttributeRoutes();

             config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}",
                  defaults: new { Controller = "Single"  }
              );

     */

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}

