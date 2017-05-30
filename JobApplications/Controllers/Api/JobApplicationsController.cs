using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using AutoMapper;

using JobApplications.Models;
using JobApplications.ViewModels;

namespace JobApplications.Controllers.Api {
   public class JobApplicationsController : ApiController {
      private job_searchEntities db = new job_searchEntities();

      protected override void Dispose(bool disposing) {
         if (disposing) {
            db.Dispose();
         }
         base.Dispose(disposing);
      }

      // GET: api/JobApplications/List
      [HttpGet]
      [Route("api/JobApplications/List")]
      public IHttpActionResult List() {
         var data = db
            .job_applications
            .Include(x => x.job_site)
            .Include(x => x.employment_agency)
            .Include(x => x.employment_agency_contact)
            .Include(x => x.latest_job_activity)
            .OrderByDescending(o => o.last_updated).ThenByDescending(o => o.application_date)
            .ToList()
            .Select(Mapper.Map<job_application, job_applicationRecord>);

         return Ok(data);
      }
   }
}