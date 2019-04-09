using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildCarsMVC.Startup))]
namespace GuildCarsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
