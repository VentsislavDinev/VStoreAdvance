using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VStyoreAdvace.Web.WebApi.Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Name",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CategoryId",
                url: "{controller}/{action}/{id}/{categoryId}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, categoryId = UrlParameter.Optional }
            );
        
            routes.MapRoute(
                name: "SpecificationId",
                url: "{controller}/{action}/{id}/{specifiId}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, specifiId = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "WithCategoryIdAndBrandId",
                url: "{controller}/{action}/{id}&{categoryId}&{brandId}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, categoryId = UrlParameter.Optional, brandId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
