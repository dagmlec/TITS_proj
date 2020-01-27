﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TiTSproj
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "ProduktyList",
                 url: "Kategoria/{nazwaKategorii}",
                 defaults: new { controller = "Produkty", action = "Lista" });


            routes.MapRoute(
                name: "StronyStatyczne", 
                url: "strony/{nazwa}.html",
                defaults: new { controller = "Home", action="StronyStatyczne"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
