using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Optimization;
using Beefry.FormBuilder;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Cosmo.Models;

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
            Config.DefaultSettings["DatabaseHostname"] = @"COOPER\SQLEXPRESS";
            //Config.DefaultSettings["DatabaseHostname"] = @"172.31.36.204\COSMO";
            Config.DefaultSettings["DatabaseUsername"] = "sa";
            Config.DefaultSettings["DatabasePassword"] = "1324#By%eish1";
            Config cosmoFBConfig = new Config(Server);

            IdentityRole adminRole = new IdentityRole("Administrator");
            IdentityRole userRole = new IdentityRole("User");
            ApplicationUser adminUser = new ApplicationUser() { UserName = "admin" };
            ApplicationDbContext context = new ApplicationDbContext();

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!RoleManager.RoleExists<IdentityRole>("Administrator"))
            {
                RoleManager.Create<IdentityRole>(adminRole);
            }

            if (!RoleManager.RoleExists<IdentityRole>("User"))
            {
                RoleManager.Create<IdentityRole>(userRole);
            }
            
            if (context.Users.ToList<ApplicationUser>().Count == 0)
            {
                ApplicationUser admin = new ApplicationUser() { UserName = "admin" };
                IdentityResult result = UserManager.Create(admin, "admin12345");
                UserManager.AddToRole<ApplicationUser>(admin.Id, "Administrator");
            }
        }
    }
}
