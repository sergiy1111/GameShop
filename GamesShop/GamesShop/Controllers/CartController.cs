using GamesShop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        public ActionResult AddToCart(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            if(Context.Products.Find(Id).Keys.Where(i => i.IsUsed == false).Count() > 0)
            {
                string UserId = User.Identity.GetUserId();
                ApplicationUser CurrentUser = Context.Users.Find(UserId);
                CurrentUser.Cart.Products.Add(Context.Products.Find(Id));
                Context.SaveChanges();
            }
       
            return null;
        }
        // GET: Cart
        public ActionResult List()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);

            return PartialView(CurrentUser.Cart.Products);
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);
            CurrentUser.Cart.Products.Remove(Context.Products.Find(Id));
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromList(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);
            CurrentUser.Cart.Products.Remove(Context.Products.Find(Id));
            Context.SaveChanges();

            return PartialView(CurrentUser.Cart.Products);
        }

        public ActionResult Index()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);

            return View(CurrentUser.Cart.Products);
        }
    }
}