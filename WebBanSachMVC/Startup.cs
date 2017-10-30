using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBanSachMVC.Startup))]
namespace WebBanSachMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
