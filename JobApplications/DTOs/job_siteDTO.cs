using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace JobApplications.DTOs {
   public class job_siteDTO {
      public int id { get; set; }

      [Display(Name = "Job Site")]
      [Required]
      public string name { get; set; }

      [Display(Name = "Web Site")]
      public string url { get; set; }

      public Nullable<System.DateTime> last_updated { get; set; }
   }
}