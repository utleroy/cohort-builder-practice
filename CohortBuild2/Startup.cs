using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CohortBuild2.Startup))]
namespace CohortBuild2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
