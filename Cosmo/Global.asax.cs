using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Optimization;
using Beefry.FormBuilder;

namespace Cosmo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //Formbuilder config
            //Config.DefaultSettings["DatabaseHostname"] = @"COOPER\SQLEXPRESS";
            Config.DefaultSettings["DatabaseHostname"] = @"172.31.36.204\COSMO";
            Config.DefaultSettings["DatabaseUsername"] = "sa";
            Config.DefaultSettings["DatabasePassword"] = "1324#By%eish1";
            Config cosmoFBConfig = new Config(Server);
        }
    }
}
