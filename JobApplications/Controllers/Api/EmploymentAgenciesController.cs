using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using JobApplications.DTOs;
using JobApplications.Models;

namespace JobApplications.Controllers.Api
{
    public class EmploymentAgenciesController : ApiController
    {
      [HttpPost]
      public IHttpActionResult Create(employment_agencyDTO employment_agencyDTO) {
         using (job_searchEntities db = new job_searchEntities()) {
            if (!ModelState.IsValid) {
               return BadRequest();
            }

            employment_agency newAgency = new employment_agency() {
               name = employment_agencyDTO.name,
               url = employment_agencyDTO.url
            };

            db.employment_agencies.Add(newAgency);
            db.SaveChanges();

            employment_agencyDTO.id = newAgency.id;
            employment_agencyDTO.last_updated = newAgency.last_updated;

            return Created<employment_agencyDTO>(new Uri(Request.RequestUri + "/" + employment_agencyDTO.id), employment_agencyDTO);
         }
      }
   }
}
