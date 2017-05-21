using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.DTOs {
   public class job_application_activityDTO {
      public int id { get; set; }
      public int job_application_id { get; set; }
      public Nullable<int> activity_type_id { get; set; }
      public string description { get; set; }
      public Nullable<System.DateTime> last_updated { get; set; }

      public virtual job_application_activity_typeDTO job_application_activity_type { get; set; }
   }
}