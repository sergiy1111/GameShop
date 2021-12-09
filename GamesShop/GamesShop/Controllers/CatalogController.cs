using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.ToList());
        }

        public ActionResult Search(string Search, double MinPrice, double MaxPrice, List<int> OS, List<int> Categories, List<int> Developers)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            List<Product> SearchProducts = Context.Products.Where(i => i.ProductName.Contains(Search)).ToList();
            SearchProducts = SearchProducts.Where(i => i.Price >= MinPrice &&  i.Price <= MaxPrice).ToList();
            if (OS != null)
            {
                foreach (var item in OS)
                {
                    SearchProducts = SearchProducts.Where(i => i.OperatingSystems.Where(j => j.Id == item).Count() > 0).ToList();
                }
            }

            if(Categories != null)
            {
                foreach (var item in Categories)
                {
                    SearchProducts = SearchProducts.Where(i => i.Categories.Where(j => j.Id == item).Count() > 0).ToList();
                }
            }

            if(Developers != null)
            {
                foreach (var item in Developers)
                {
                    SearchProducts = SearchProducts.Where(i => i.Developer.Id == item).ToList();
                }
            }
        
            return PartialView(SearchProducts);
        }

        public ActionResult Details(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Products.Find(Id));
        }
    }
}