using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PrismMobileApp.Startup))]

namespace PrismMobileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}