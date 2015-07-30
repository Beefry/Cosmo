using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;

namespace Cosmo.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/
        public ActionResult Index()
        {
            FormDataAdapter adapter = new FormDataAdapter();
            List<Form> Forms;
            try
            {
                Forms = adapter.GetForms();
                return View(Forms);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error in Index: " + ex.Message;
                return View((object)null);
            }
        }

        //
        // GET: /Form/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.FormAPIPath = "/API/Form/";
            ViewBag.redirectPath = Url.Action("Index");
            return View(id);
        }

        //
        // GET: /Form/Create
        public ActionResult Create(int? id)
        {
            ViewBag.FormAPIPath = "/API/Form/";
            ViewBag.redirectPath = Url.Action("Index");
            if (id.HasValue)
                return View(id);
            else
                return View();
        }

        //
        // GET: /Form/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.FormAPIPath = "/API/Form/";
            ViewBag.redirectPath = Url.Action("Index");
            if (id.HasValue)
            {
                return View(id);
            }
            else
            {
                return View();
            }
            
        }

        //
        // POST: /Form/Edit/5
        [HttpPost]
        public ActionResult Edit(Form collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
