﻿using System.Web;
using System.Web.Mvc;
using Authentication.Infrastructure;

namespace Authentication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomActionFilter());

        }
    }
}
