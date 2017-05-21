using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.DTOs {
   public class latest_job_activityDTO {
      public int job_application_id { get; set; }
      public Nullable<int> activity_type_id { get; set; }
      public string description { get; set; }
      public DateTime? activity_date { get; set; }
      public DateTime? last_updated { get; set; }
      public int job_application_activity_id { get; set; }

      public job_application_activity_typeDTO job_application_activity_type { get; set; }
   }
}