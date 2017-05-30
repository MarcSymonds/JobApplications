using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using JobApplications.DTOs;
using JobApplications.Models;

namespace JobApplications.ViewModels {
   /// <summary>
   /// For the list/index view.
   /// </summary>
   public class job_applicationVMList {
      public IEnumerable<job_applicationRecord> job_applications { get; set; }

      public string search { get; set; }
   }
}