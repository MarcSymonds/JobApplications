using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using JobApplications.DTOs;
namespace JobApplications.Models {
   public class job_applicationRecord : job_applicationDTOBase {
      public job_applicationRecord() {
         //latest_job_activity = new HashSet<latest_job_activityDTO>();
      }

      [Display(Name = "Job Site")]
      public job_siteDTO job_site { get; set; }

      [Display(Name = "Employment Agency")]
      public employment_agencyDTO employment_agency { get; set; }

      [Display(Name = "Agency Contact")]
      public employment_agency_contactDTO employment_agency_contact { get; set; }

      public ICollection<latest_job_activityDTO> latest_job_activity { get; set; }
   }
}