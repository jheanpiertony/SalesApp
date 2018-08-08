using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesApp.Backend.Startup))]
namespace SalesApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
