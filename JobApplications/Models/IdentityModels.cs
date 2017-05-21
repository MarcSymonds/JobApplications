using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobApplications.Models {
   // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   public class ApplicationUser : IdentityUser {
      public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager) {
         // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
         var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
         // Add custom user claims here
         return userIdentity;
      }
   }

   public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
      public DbSet<job_application> job_applications { get; set; }
      public DbSet<job_site> job_sites { get; set; }
      public DbSet<employment_agency> emplyoment_agencies { get; set; }
      public DbSet<employment_agency_contact> employment_agency_contacts { get; set; }
      public DbSet<job_application_activity> job_application_activity { get; set; }
      public DbSet<job_application_activity_type> job_application_activity_type { get; set; }
      public DbSet<latest_job_activity> latest_job_activity { get; set; }

      public ApplicationDbContext() : base("JobSearch", throwIfV1Schema: false) {
      }

      public static ApplicationDbContext Create() {
         return new ApplicationDbContext();
      }
   }
}