using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WellspringIABService.Startup))]

namespace WellspringIABService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}