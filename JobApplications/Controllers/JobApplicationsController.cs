using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using AutoMapper;

using JobApplications.DTOs;
using JobApplications.Models;
using JobApplications.ViewModels;

namespace JobApplications.Controllers {
   public class JobApplicationsController : Controller {
      private job_searchEntities db = new job_searchEntities();// ApplicationDbContext db = new ApplicationDbContext();

      // LINQ version of the Entity query below.
      /*
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
      */

      // GET: job_applications
      public ActionResult Index() {
         var data = db
            .job_applications
            .Include(x => x.job_site)
            .Include(x => x.employment_agency)
            .Include(x => x.employment_agency_contact)
            .Include(x => x.latest_job_activity)
            .OrderByDescending(o => o.last_updated).ThenByDescending(o => o.application_date)
            .ToList()
            .Select(Mapper.Map<job_application, job_applicationVMList>);

         return View(data);
      }

      // GET: job_applications/Edit/5
      public ActionResult Edit(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         job_application job_application = db.job_applications.Find(id);

         if (job_application == null) {
            return HttpNotFound();
         }

         job_applicationVMEdit edit = Mapper.Map<job_applicationVMEdit>(job_application);

         edit.employment_agencies = db
            .employment_agencies
            .ToList()
            .Select(Mapper.Map<employment_agency, employment_agencyDTO>);

         edit.employment_agency_contacts = db
            .employment_agency_contacts
            .Where(w => w.employment_agency_id == edit.employment_agency_id)
            .OrderBy(o => o.contact_name)
            .ToList()
            .Select(Mapper.Map<employment_agency_contact, employment_agency_contactDTO>);

         edit.job_sites = db.job_sites.ToList().Select(Mapper.Map<job_site, job_siteDTO>);

         return View(edit);
      }


      // GET: job_applications/Details/5
      public ActionResult Details(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         var job_application = db.job_applications
            .Include(x => x.job_site)
            .Include(x => x.employment_agency)
            .Include(x => x.employment_agency_contact)
            .FirstOrDefault(f => f.id == id);

         if (job_application == null) {
            return HttpNotFound();
         }

         return View(Mapper.Map(job_application, job_application.GetType(), typeof(job_applicationVMList)));
      }

      // GET: job_applications/Create
      public ActionResult Create() {
         job_applicationVMEdit edit = new job_applicationVMEdit() {
            id = 0
         };

         edit.employment_agencies = db
            .employment_agencies
            .ToList()
            .Select(Mapper.Map<employment_agency, employment_agencyDTO>);

         edit.employment_agency_contacts = new HashSet<employment_agency_contactDTO>();

         edit.job_sites = db
            .job_sites
            .ToList()
            .Select(Mapper.Map<job_site, job_siteDTO>);


         return View("Edit", edit);
      }

      // POST: job_applications/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Save(job_applicationDTOBase job_application) {
         if (!ModelState.IsValid) {
            string errors = "";

            foreach (var value in ModelState.Values) {
               foreach (var error in value.Errors) {
                  if (errors.Length > 0) {
                     errors += " ";
                  }
                  errors += error.ErrorMessage;
               }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, errors);
         }
         else {
            job_application save;
            if (job_application.id == 0) { // New record.
               save = Mapper.Map<job_application>(job_application);
               save.last_updated = DateTime.Now;
               db.job_applications.Add(save);
            }
            else {
               save = db.job_applications.Find(job_application.id);

               if (save == null) {
                  return HttpNotFound();
               }

               Mapper.Map(job_application, save, job_application.GetType(), typeof(job_application));

               /*save.job_site_id = job_application.job_site_id;
               save.job_site_reference = job_application.job_site_reference;
               save.employment_agency_id = job_application.employment_agency_id;
               save.employment_agency_contact_id = job_application.employment_agency_contact_id;
               save.employment_agency_reference = job_application.employment_agency_reference;
               save.company_name = job_application.company_name;
               save.company_location = job_application.company_location;
               save.job_title = job_application.job_title;*/

               save.last_updated = DateTime.Now;
            }

            db.SaveChanges();
         }

         return RedirectToAction("Index");
      }

/*      // POST: job_applications/Edit/5
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
      }*/

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
