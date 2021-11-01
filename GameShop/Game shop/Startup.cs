using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Game_shop.Startup))]
namespace Game_shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
