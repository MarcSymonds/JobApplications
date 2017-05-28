using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JobApplications.DTOs;
using JobApplications.Models;

namespace JobApplications.ViewModels {
   public class job_application_activityVMEdit : job_application_activityDTO {

      public IEnumerable<job_application_activity_typeDTO> job_application_activity_types { get; set; }
   }
}