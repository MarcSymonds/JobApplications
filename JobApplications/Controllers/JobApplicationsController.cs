using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobApplications.Models;

namespace JobApplications.Controllers {
   public class JobApplicationsController : Controller {
      private job_searchEntities db = new job_searchEntities();// ApplicationDbContext db = new ApplicationDbContext();

      // GET: job_applications
      public ActionResult Index() {
         var a = from t in db.job_applications
                 join jsx in db.job_sites on t.job_site_id equals jsx.id into jsy
                 from js in jsy.DefaultIfEmpty()
                 join eax in db.employment_agencies on t.employment_agency_id equals eax.id into eay
                 from ea in eay.DefaultIfEmpty()
                 join eacx in db.employment_agency_contacts on t.employment_agency_contact_id equals eacx.id into eacy
                 from eac in eacy.DefaultIfEmpty()
                 where t.application_date >= new DateTime(2017, 5, 1)
                 orderby t.application_date descending, t.last_updated descending
                 select new {
                    t.id,
                    job_site_name = js.name,
                    t.job_site_reference,
                    employment_agency_name = ea.name,
                    emplyment_agency_contact_name = eac.contact_name,
                    t.employment_agency_reference,
                    t.company_name,
                    t.company_location,
                    t.job_title,
                    t.application_date,
                    t.last_updated
                 };


         foreach (var b in a) {
            Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5:dd/MM/yyyy HH:mm:ss} {6:dd/MM/yyyy HH:mm:ss}", 
               b.id, 
               b.job_site_name ?? "NULL", 
               b.job_site_reference ?? "NULL",
               b.employment_agency_name?? "NULL",
               b.emplyment_agency_contact_name?? "NULL",
               b.application_date,
               b.last_updated
               ));
         }

                 //where t.last_updated > "2017-09-01"

         return View(db
            .job_applications
            .Include(x => x.job_site)
            .Include(x => x.employment_agency)
            .Include(x => x.employment_agency_contact)
            .OrderByDescending(o => o.application_date).ThenByDescending(o => o.last_updated)
            .Where(w => w.application_date >= new DateTime(2017,5,1))
            .ToList());
      }

      // GET: job_applications/Details/5
      public ActionResult Details(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         job_application job_applications = db.job_applications.Find(id);
         if (job_applications == null) {
            return HttpNotFound();
         }
         return View(job_applications);
      }

      // GET: job_applications/Create
      public ActionResult Create() {
         return View();
      }

      // POST: job_applications/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "id,job_site_id,job_site_reference,employment_agency_id,employment_agency_contact_id,employment_agency_reference,company_name,company_location,job_title,application_date,last_updated")] job_application job_applications) {
         if (ModelState.IsValid) {
            db.job_applications.Add(job_applications);
            db.SaveChanges();
            return RedirectToAction("Index");
         }

         return View(job_applications);
      }

      // GET: job_applications/Edit/5
      public ActionResult Edit(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         job_application job_applications = db.job_applications.Find(id);
         if (job_applications == null) {
            return HttpNotFound();
         }
         return View(job_applications);
      }

      // POST: job_applications/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "id,job_site_id,job_site_reference,employment_agency_id,employment_agency_contact_id,employment_agency_reference,company_name,company_location,job_title,application_date,last_updated")] job_application job_applications) {
         if (ModelState.IsValid) {
            db.Entry(job_applications).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(job_applications);
      }

      // GET: job_applications/Delete/5
      public ActionResult Delete(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         job_application job_applications = db.job_applications.Find(id);
         if (job_applications == null) {
            return HttpNotFound();
         }
         return View(job_applications);
      }

      // POST: job_applications/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id) {
         job_application job_applications = db.job_applications.Find(id);
         db.job_applications.Remove(job_applications);
         db.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing) {
         if (disposing) {
            db.Dispose();
         }
         base.Dispose(disposing);
      }
   }
}
