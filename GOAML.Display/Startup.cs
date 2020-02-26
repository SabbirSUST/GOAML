using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GOAML.Display.Startup))]
namespace GOAML.Display
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
