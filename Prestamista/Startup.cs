using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prestamista.Startup))]
namespace Prestamista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
