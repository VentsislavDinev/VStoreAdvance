using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VStoreAdvanceAdvance.Web.Administration.Startup))]
namespace VStoreAdvanceAdvance.Web.Administration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
