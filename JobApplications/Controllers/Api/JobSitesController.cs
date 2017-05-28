using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using JobApplications.DTOs;
using JobApplications.Models;

namespace JobApplications.Controllers.Api {
   public class JobSitesController : ApiController {
      [HttpPost]
      public IHttpActionResult Create(job_siteDTO job_siteDTO) {
         using (job_searchEntities db = new job_searchEntities()) {
            if (!ModelState.IsValid) {
               return BadRequest();
            }

            job_site newSite = new job_site() {
               name = job_siteDTO.name,
               url = job_siteDTO.url
            };

            db.job_sites.Add(newSite);
            db.SaveChanges();

            job_siteDTO.id = newSite.id;
            job_siteDTO.last_updated = newSite.last_updated;

            return Created<job_siteDTO>(new Uri(Request.RequestUri + "/" + job_siteDTO.id), job_siteDTO);
         }
      }
   }
}
