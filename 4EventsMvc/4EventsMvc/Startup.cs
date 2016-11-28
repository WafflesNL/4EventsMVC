using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4EventsMvc.Startup))]
namespace _4EventsMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
