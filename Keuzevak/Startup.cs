using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Keuzevak.Startup))]
namespace Keuzevak
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
