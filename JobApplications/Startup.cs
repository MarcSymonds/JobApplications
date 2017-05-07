using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobApplications.Startup))]
namespace JobApplications
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
