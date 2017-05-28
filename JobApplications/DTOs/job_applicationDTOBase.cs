using System;
using System.ComponentModel.DataAnnotations;

using JobApplications.Custom.ValidationAttributes;

namespace JobApplications.DTOs {
   public class job_applicationDTOBase {
      public int id { get; set; }

      [Display(Name = "Job Site")]
      public Nullable<int> job_site_id { get; set; }

      [Display(Name = "Site Reference")]
      [MaxLength(50)]
      public string job_site_reference { get; set; }

      [Display(Name = "Employment Agency")]
      public Nullable<int> employment_agency_id { get; set; }

      [Display(Name = "Agency Contact")]
      public Nullable<int> employment_agency_contact_id { get; set; }

      [Display(Name = "Agency Reference")]
      [MaxLength(50)]
      public string employment_agency_reference { get; set; }

      [Display(Name = "Company")]
      [MaxLength(45)]
      public string company_name { get; set; }

      [Display(Name = "Company Location")]
      [MaxLength(200)]
      [DataType(DataType.MultilineText)]
      public string company_location { get; set; }

      [Display(Name = "Role")]
      [MaxLength(45)]
      public string job_title { get; set; }

      [Display(Name = "Application Date", Prompt = "DD/MM/YYYY HH:mm:ss", Description = "Date applied for role")]
      [DataType("datetime")]
      [MyDateTime()]
      public Nullable<System.DateTime> application_date { get; set; }

      [Display(Name = "Last Updated", Prompt = "DD/MM/YYYY HH:mm:ss", Description = "Date applied for role")]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
      public System.DateTime last_updated { get; set; }
   }
}