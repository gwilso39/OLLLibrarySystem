﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OLLLibrarySystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Book",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Book", action = "List", category = (string)null },
                new { page = @"\d+" }
            );

            routes.MapRoute(null,
                "{Genre}",
                new { controller = "Book", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{Genre}/Page{page}",
                new { controller = "Book", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
