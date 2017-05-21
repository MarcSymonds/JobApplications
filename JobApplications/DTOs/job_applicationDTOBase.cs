using System;
using System.ComponentModel.DataAnnotations;

namespace JobApplications.DTOs {
   public class job_applicationDTOBase {
      public int id { get; set; }

      public Nullable<int> job_site_id { get; set; }

      [Display(Name = "Job Site Reference")]
      public string job_site_reference { get; set; }

      public Nullable<int> employment_agency_id { get; set; }

      public Nullable<int> employment_agency_contact_id { get; set; }

      public string employment_agency_reference { get; set; }

      [Display(Name = "Company")]
      public string company_name { get; set; }

      [Display(Name = "Company Location")]
      public string company_location { get; set; }

      [Display(Name = "Role")]
      public string job_title { get; set; }

      public Nullable<System.DateTime> application_date { get; set; }

      [Display(Name = "Last Updated")]
      public System.DateTime last_updated { get; set; }
   }
}