﻿using Roldaice.Web.Attributes;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogHandleErrorAttribute(), 10);
        }
    }
}
