using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobApplications.Controllers
{
    public class JobSitesController : Controller
    {
        // GET: JobSites
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobSites/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobSites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSites/Create
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

        // GET: JobSites/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobSites/Edit/5
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

        // GET: JobSites/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobSites/Delete/5
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
