using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;

namespace Cosmo.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public void Index()
        {
            //TODO: redirect to Dashboard
            RedirectToAction("Dashboard");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[Authorize]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}