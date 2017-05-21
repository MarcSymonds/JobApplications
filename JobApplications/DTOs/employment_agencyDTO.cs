using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.DTOs {
   public class employment_agencyDTO {
      public int id { get; set; }
      public string name { get; set; }
      public string url { get; set; }
      public Nullable<System.DateTime> last_updated { get; set; }
   }
}
