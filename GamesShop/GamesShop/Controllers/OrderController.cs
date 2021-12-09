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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Create()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);
            if (CurrentUser.Cart.Products.Count > 0)
            {
                return View(CurrentUser.Cart.Products.ToList());
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Create(List<int> Products, double Summary, string Email)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);
            if (CurrentUser.Cart.Products.Count > 0)
            {
                Key Key;
                Order NewOrder = new Order();
                foreach (var Item in Products)
                {
                    Key = Context.Products.Find(Item).Keys.Where(i => i.IsUsed == false).FirstOrDefault();
                    Key.IsUsed = true;
                    NewOrder.Keys.Add(Key);
                    CurrentUser.Cart.Products.Remove(Context.Products.Find(Item));
                }

                NewOrder.Summary = Summary;
                NewOrder.User = CurrentUser;
                CurrentUser.Orders.Add(NewOrder);


                Context.SaveChanges();

                return RedirectToAction("History");
            }
            return HttpNotFound();
        }

        public ActionResult History()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);

            return View(CurrentUser.Orders.ToList());
        }
    }
}