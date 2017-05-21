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

namespace JobApplications.Controllers.Api
{
    public class JobApplicationsController : ApiController
    {
        private job_searchEntities db = new job_searchEntities();

        // GET: api/JobApplications/List
        [HttpGet]
        [Route("api/JobApplications/List")]
        public IHttpActionResult List()
        {
         var data = db
            .job_applications
            .Include(x => x.job_site)
            .Include(x => x.employment_agency)
            .Include(x => x.employment_agency_contact)
            .Include(x => x.latest_job_activity)
            .OrderByDescending(o => o.last_updated).ThenByDescending(o => o.application_date)
            .ToList()
            .Select(Mapper.Map<job_application, job_applicationVMList>);

         return Ok(data);
        }

        // GET: api/job_application/5
        [ResponseType(typeof(job_application))]
        public IHttpActionResult Getjob_application(int id)
        {
            job_application job_application = db.job_applications.Find(id);
            if (job_application == null)
            {
                return NotFound();
            }

            return Ok(job_application);
        }

        // PUT: api/job_application/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putjob_application(int id, job_application job_application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job_application.id)
            {
                return BadRequest();
            }

            db.Entry(job_application).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!job_applicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/job_application
        [ResponseType(typeof(job_application))]
        public IHttpActionResult Postjob_application(job_application job_application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.job_applications.Add(job_application);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = job_application.id }, job_application);
        }

        // DELETE: api/job_application/5
        [ResponseType(typeof(job_application))]
        public IHttpActionResult Deletejob_application(int id)
        {
            job_application job_application = db.job_applications.Find(id);
            if (job_application == null)
            {
                return NotFound();
            }

            db.job_applications.Remove(job_application);
            db.SaveChanges();

            return Ok(job_application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool job_applicationExists(int id)
        {
            return db.job_applications.Count(e => e.id == id) > 0;
        }
    }
}