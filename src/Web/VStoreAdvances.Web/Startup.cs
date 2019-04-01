using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VStoreAdvances.Web.Startup))]
namespace VStoreAdvances.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
