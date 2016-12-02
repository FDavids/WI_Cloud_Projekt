using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniCloudMVC.Startup))]
namespace MiniCloudMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
