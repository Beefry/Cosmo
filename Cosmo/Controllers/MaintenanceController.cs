using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;

namespace Cosmo.Controllers
{
    public class MaintenanceController : Controller
    {
        public MaintenanceController()
        {
            Dictionary<string, string> FormBuilder = new Dictionary<string, string>();
            FormBuilder.Add("fid", "");
            FormBuilder.Add("tid", "");
            ViewBag.FormBuilder = FormBuilder;
        }

        //
        // GET: /Maintenance/
        public ActionResult Index()
        {
            FormDataAdapter adapter = new FormDataAdapter();
            List<Form> Forms = adapter.GetForms(TemplateID:3);
            return View(Forms);
        }

        //
        // GET: /Maintenance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Maintenance/Create
        public ActionResult Create()
        {
            ViewBag.FormBuilder["tid"] = "1";
            return View();
        }

        //
        // POST: /Maintenance/Create
        [HttpPost]
        public ActionResult Create(Form Form)
        {
            try
            {
                // TODO: Add insert logic here

                if (Form != null)
                {
                    try
                    {
                        Form.Save();
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;
                    }
                }
                else
                {
                    ViewBag.Error = "No data was sent to the server.";
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Maintenance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Maintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(Form Form)
        {
            if (Form != null)
            {
                try
                {
                    Form.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            else
            {
                ViewBag.Error = "No data was sent to the server.";
            }
            return View();
        }

        //
        // GET: /Maintenance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
