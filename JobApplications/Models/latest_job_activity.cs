//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobApplications.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class latest_job_activity
    {
        public int job_application_id { get; set; }
        public Nullable<int> activity_type_id { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> last_updated { get; set; }
        public int job_application_activity_id { get; set; }
        public Nullable<System.DateTime> activity_date { get; set; }
    
        public virtual job_application_activity job_application_activity { get; set; }
        public virtual job_application_activity_type job_application_activity_type { get; set; }
        public virtual job_application job_application { get; set; }
    }
}
