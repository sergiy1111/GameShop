using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesShop.Models;


namespace GamesShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Products.ToList());
        }

        public ActionResult Categories()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Categories.ToList());
        }

        public ActionResult Developers()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Developers.ToList());
        }
     
        public ActionResult Publishers()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Publishers.ToList());
        }

        public ActionResult OperatingSystems()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.OperatingSystems.ToList().OrderByDescending(i => i.Id).ToList());
        }
    }
}