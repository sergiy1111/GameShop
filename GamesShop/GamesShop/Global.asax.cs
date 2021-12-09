using GamesShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GamesShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new AdminInitializer());

            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var user = userManager.FindByNameAsync("Admin");
            var role = roleManager.FindByNameAsync("Administrator");
            if(user.IsCompleted && role.IsCompleted)
            {
                if(role.Result == null)
                {
                    var role1 = new IdentityRole { Name = "Administrator" };

                    roleManager.Create(role1);
                }
                if(user.Result == null)
                {
                    var admin = new ApplicationUser { Email = "aquaitstep@gmail.com", UserName = "Admin", Cart = new Cart() };
                    string password = "Admin 11111";
                    var result = userManager.Create(admin, password);
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(admin.Id, "Administrator");
                    }
                }
            }        

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
