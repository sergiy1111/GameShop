using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Input(int? Id)
        {
            Category Model = new Models.Category();
            if (Id.Value == -1)
            {
                Model.Id = -1;
                Model.CategoryName = "";
            }
            else
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Model.Id = Id.Value;
                Model.CategoryName = Context.Categories.Find(Id.Value).CategoryName;
            }
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult Input(GamesShop.Models.Category Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            if (Context.Categories.Where(i => i.CategoryName == Model.CategoryName).Count() > 0)
            {
                return PartialView(Model);
            }
            if (ModelState.IsValid)
            {
                if (Model.Id == -1)
                {
                    Models.Category NewCategory = new Models.Category();
                    NewCategory.CategoryName = Model.CategoryName;
                    Context.Categories.Add(NewCategory);
                    Context.SaveChanges();
                }
                else
                {
                    Context.Categories.Find(Model.Id).CategoryName = Model.CategoryName;
                    Context.SaveChanges();
                }
                return PartialView(Model);
            }
            else
            {
                return PartialView(Model);
            }
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Categories.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(GamesShop.Models.Category Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Categories.Remove(Context.Categories.Find(Model.Id));
            Context.SaveChanges();
            return PartialView(Model);
        }
    }
}