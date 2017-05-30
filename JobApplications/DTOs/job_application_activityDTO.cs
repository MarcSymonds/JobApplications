using System;
using System.ComponentModel.DataAnnotations;

using JobApplications.Custom.ValidationAttributes;

namespace JobApplications.DTOs {
   public class job_application_activityDTO {
      public int id { get; set; }
      public int job_application_id { get; set; }

      [Display(Name = "Activity Type")]
      public int? activity_type_id { get; set; }

      [Display(Name = "Description")]
      [DataType(DataType.MultilineText)]
      public string description { get; set; }

      [Display(Name = "Activity Date", Prompt = "DD/MM/YYYY HH:mm:ss", Description = "Date of activity")]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
      [MyDateTime()]
      public DateTime? activity_date { get; set; }

      [Display(Name = "Last Updated", Prompt = "DD/MM/YYYY HH:mm:ss", Description = "Last updated")]
      //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
      public DateTime? last_updated { get; set; }

      [Display(Name = "Activity Type")]
      public virtual job_application_activity_typeDTO job_application_activity_type { get; set; }
   }
}