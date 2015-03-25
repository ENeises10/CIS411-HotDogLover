using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS411HotDog.Startup))]
namespace CIS411HotDog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
