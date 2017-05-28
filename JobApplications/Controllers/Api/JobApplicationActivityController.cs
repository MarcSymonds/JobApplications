using JobApplications.Models;
using System.Web.Http;

namespace JobApplications.Controllers.Api {
   public class JobApplicationActivityController : ApiController {
      [HttpDelete]
      public IHttpActionResult Delete(int id) {
         using (job_searchEntities db = new job_searchEntities()) {
            job_application_activity activity = db.job_application_activity.Find(id);

            if (activity == null) {
               return NotFound();
            }

            db.job_application_activity.Remove(activity);
            db.SaveChanges();

            return Ok();
         }
      }
   }
}
