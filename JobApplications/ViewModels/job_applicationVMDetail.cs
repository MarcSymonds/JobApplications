using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

using JobApplications.DTOs;

namespace JobApplications.ViewModels {
   public class job_applicationVMDetail : job_applicationDTOBase {
      [Display(Name = "Job Site")]
      public job_siteDTO job_site { get; set; }

      [Display(Name = "Employment Agency")]
      public employment_agencyDTO employment_agency { get; set; }

      [Display(Name = "Agency Contact")]
      public employment_agency_contactDTO employment_agency_contact { get; set; }

      public List<job_application_activityDTO> job_application_activity { get; set; }
   }
}