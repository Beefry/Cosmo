using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beefry.FormBuilder;
using System.Web.Security;

namespace Cosmo.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/
        [Authorize]
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
        [Authorize]
        public ActionResult Details(int id)
        {
            ViewBag.FormAPIPath = "/API/Form/";
            ViewBag.redirectPath = Url.Action("Index");
            return View(id);
        }

        //
        // GET: /Form/Create
        [Authorize]
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
        [Authorize]
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
    }
}
