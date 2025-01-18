using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DerekPersonalMVC.Startup))]
namespace DerekPersonalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
