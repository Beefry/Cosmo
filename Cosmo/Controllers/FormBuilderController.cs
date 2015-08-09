using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;
using System.IO;

namespace Cosmo.Controllers
{
    public class FormBuilderController : Controller
    {
        //
        // GET: /Form/
        [Authorize]
        public ActionResult Index()
        {
            Beefry.FormBuilder.TemplateDataAdapter adapter = new TemplateDataAdapter();
            Beefry.FormBuilder.TemplateCollection templates = adapter.GetTemplates();
            return View(templates);
        }

        //
        // GET: /Form/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Form/Create
        [Authorize]
        public ActionResult Create()
        {
            
            ViewBag.FormAPIPath = "/API/Template/";
            ViewBag.redirectPath = Url.Action("Index");
            return View();
        }

        //
        // GET: /Form/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.FormAPIPath = "/API/Template/";
            ViewBag.redirectPath = Url.Action("Index");
            ViewBag.FormBuilderID = id;
            return View();
        }
    }
}
