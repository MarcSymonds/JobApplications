using AutoMapper;
using JobApplications.DTOs;
using JobApplications.Models;
using JobApplications.ViewModels;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace JobApplications.Controllers {
   public class JobApplicationActivityController : Controller {
      private job_searchEntities db = new job_searchEntities();

      protected override void Dispose(bool disposing) {
         if (disposing) {
            db.Dispose();
         }
         base.Dispose(disposing);
      }

      [HttpGet]
      public ActionResult Edit(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }

         job_application_activity data = db.job_application_activity.Find(id);

         if (data == null) {
            return HttpNotFound();
         }

         job_application_activityVMEdit viewModel = Mapper.Map<job_application_activityVMEdit>(data);

         viewModel.job_application_activity_types = db
            .job_application_activity_type
            .OrderBy(o => o.description)
            .ToList()
            .Select(Mapper.Map<job_application_activity_type, job_application_activity_typeDTO>);

         return View(viewModel);
      }

      [HttpGet]
      public ActionResult Create(int applicationId) {
         job_application_activityVMEdit viewModel = new job_application_activityVMEdit() {
            id = 0,
            job_application_id = applicationId,
            activity_date = DateTime.Now
         };

         viewModel.job_application_activity_types = db
            .job_application_activity_type
            .OrderBy(o => o.description)
            .ToList()
            .Select(Mapper.Map<job_application_activity_type, job_application_activity_typeDTO>);

         return View("Edit", viewModel);
      }

      [HttpPost]
      public ActionResult Save(job_application_activityDTO activityToSave) {
         job_application_activity save;

         if (activityToSave.id == 0) { // New record.
            save = Mapper.Map<job_application_activity>(activityToSave);
            save.last_updated = DateTime.Now;
            db.job_application_activity.Add(save);
         }
         else {
            save = db.job_application_activity.Find(activityToSave.id);

            if (save == null) {
               return HttpNotFound();
            }

            save.activity_type_id = activityToSave.activity_type_id;
            save.description = activityToSave.description;
            save.activity_date = activityToSave.activity_date;
            save.last_updated = DateTime.Now;
         }

         db.SaveChanges();

         return RedirectToAction("Details", "JobApplications", new { id = activityToSave.job_application_id });
      }
   }
}