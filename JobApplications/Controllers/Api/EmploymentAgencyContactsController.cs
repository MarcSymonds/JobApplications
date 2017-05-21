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

      /// <summary>
      /// Get list of contacts for a specific employment agency.
      /// </summary>
      /// <param name="agencyid">The ID of the agency to retrieve contacts for</param>
      /// <returns></returns>
      [Route("api/EmploymentAgencyContacts/{agencyid}")]
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
