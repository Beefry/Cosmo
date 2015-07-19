using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cosmo.Startup))]
namespace Cosmo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
