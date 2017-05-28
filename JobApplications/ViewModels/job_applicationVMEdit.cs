using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using JobApplications.DTOs;

namespace JobApplications.ViewModels {
   public class job_applicationVMEdit : job_applicationDTOBase {
      [Display(Name = "Job Site")]
      public IEnumerable<job_siteDTO> job_sites { get; set; }

      [Display(Name = "Employment Agency")]
      public IEnumerable<employment_agencyDTO> employment_agencies { get; set; }

      /// <summary>
      /// List of agency contacts for the current agency. These will initially be displayed
      /// in the edit form. The edit form will update the list if a different agency is
      /// selected.
      /// </summary>
      [Display(Name = "Agency Contact")]
      public IEnumerable<employment_agency_contactDTO> employment_agency_contacts { get; set; }

      // These are just needed so that the View can reference these objects.
      public job_siteDTO job_site { get; set; }
      public employment_agencyDTO employment_agency { get; set; }
      public employment_agency_contactDTO employment_agency_contact { get; set; }
   }
}