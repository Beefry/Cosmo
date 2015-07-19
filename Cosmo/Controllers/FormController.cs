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
        public ActionResult Index()
        {
            Beefry.FormBuilder.TemplateDataAdapter adapter = new TemplateDataAdapter();
            Beefry.FormBuilder.TemplateCollection templates = adapter.GetTemplates();
            return View(templates);
        }

        //
        // GET: /Form/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Form/Create
        public ActionResult Create()
        {
            ViewBag.FormAPIPath = Url.Action("Create");
            ViewBag.redirectPath = Url.Action("Index");
            return View();
        }

        //
        // GET: /Form/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.FormAPIPath = Url.Action("Create");
            ViewBag.redirectPath = Url.Action("Index");
            ViewBag.FormBuilderID = id;
            return View();
        }

        //
        // GET: /Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Form/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Beefry.FormBuilder.FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
