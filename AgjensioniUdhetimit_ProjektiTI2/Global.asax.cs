using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AgjensioniUdhetimit_ProjektiTI2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender,EventArgs e)
        {
            HttpContext httpContext = HttpContext.Current;
            var langSession = "en";
            if (httpContext != null && httpContext.Session != null)
            {
                langSession = httpContext.Session["lang"] != null ? httpContext.Session["lang"].ToString() : "en";
             }

           
                Thread.CurrentThread.CurrentCulture = new CultureInfo(langSession);
               Thread.CurrentThread.CurrentCulture = new CultureInfo(langSession);

            
        }
        
    }
}
