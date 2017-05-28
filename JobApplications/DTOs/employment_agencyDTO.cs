﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobApplications.DTOs {
   public class employment_agencyDTO {
      public int id { get; set; }

      [Display(Name = "Employment Agency")]
      public string name { get; set; }

      [Display(Name = "Web Site URL")]
      public string url { get; set; }
      public Nullable<System.DateTime> last_updated { get; set; }
   }
}
