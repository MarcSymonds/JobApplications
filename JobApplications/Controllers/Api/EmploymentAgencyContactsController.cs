using System;
using System.Linq;
using System.Web.Http;

using AutoMapper;

using JobApplications.Models;
using JobApplications.DTOs;

namespace JobApplications.Controllers.Api {
   public class EmploymentAgencyContactsController : ApiController {
      private job_searchEntities db = new job_searchEntities();

      protected override void Dispose(bool disposing) {
         if (disposing) {
            db.Dispose();
         }
         base.Dispose(disposing);
      }

      [Route("api/EmploymentAgencyContacts/Create")]
      [HttpPost]
      public IHttpActionResult Create(employment_agency_contactDTO employment_agency_contactDTO) {
         if (!ModelState.IsValid) {
            return BadRequest();
         }

         employment_agency_contact newContact = new employment_agency_contact() {
            employment_agency_id = employment_agency_contactDTO.employment_agency_id,
            contact_name = employment_agency_contactDTO.contact_name,
            contact_email = employment_agency_contactDTO.contact_email,
            contact_telephone = employment_agency_contactDTO.contact_telephone
         };

         db.employment_agency_contacts.Add(newContact);
         db.SaveChanges();

         employment_agency_contactDTO.id = newContact.id;
         employment_agency_contactDTO.last_updated = newContact.last_updated;

         return Created(new Uri(Request.RequestUri + "/" + employment_agency_contactDTO.id), employment_agency_contactDTO);
      }

      /// <summary>
      /// Get list of contacts for a specific employment agency.
      /// </summary>
      /// <param name="agencyid">The ID of the agency to retrieve contacts for</param>
      /// <returns></returns>
      [Route("api/EmploymentAgencyContacts/{agencyid:regex(\\d+)}")]
      [HttpGet]
      public IHttpActionResult EmploymentAgencyContacts(int agencyid) {
         var data = db
            .employment_agency_contacts
            .Where(w => w.employment_agency_id == agencyid)
            .Select(Mapper.Map<employment_agency_contact, employment_agency_contactDTO>)
            .OrderBy(o => o.contact_name)
            .ToList();

         return Ok(data);
      }

   }
}
