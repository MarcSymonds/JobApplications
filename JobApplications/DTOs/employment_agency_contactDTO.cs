﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace JobApplications.DTOs {
   public class employment_agency_contactDTO {

      public int id { get; set; }
      public Nullable<int> employment_agency_id { get; set; }

      [Display(Name = "Contact Name")]
      public string contact_name { get; set; }

      [Display(Name = "Contact Email")]
      public string contact_email { get; set; }

      [Display(Name = "Contact Telephone")]
      public string contact_telephone { get; set; }

      public System.DateTime last_updated { get; set; }
   }
}