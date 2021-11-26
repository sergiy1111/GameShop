using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamesShop.Startup))]
namespace GamesShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
