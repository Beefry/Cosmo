using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;

namespace Cosmo.Controllers
{
    public class PMFormsController : Controller
    {
        //
        // GET: /PMForms/
        public ActionResult Index()
        {
            FormDataAdapter adapter = new FormDataAdapter();
            List<Form> forms = adapter.GetForms(User.IsInRole("Administrator"));
            return View();
        }

        //
        // GET: /PMForms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PMForms/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PMForms/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PMForms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PMForms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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
        // GET: /PMForms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PMForms/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
