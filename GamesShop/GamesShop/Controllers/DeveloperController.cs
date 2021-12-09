using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DeveloperController : Controller
    {
        // GET: Developer
        public ActionResult Input(int? Id)
        {
            Developer Model = new Models.Developer();
            if (Id.Value == -1)
            {
                Model.Id = -1;
                Model.DeveloperName = "";
            }
            else
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Model.Id = Id.Value;
                Model.DeveloperName = Context.Developers.Find(Id.Value).DeveloperName;
            }
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult Input(GamesShop.Models.Developer Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            if (Context.Developers.Where(i => i.DeveloperName == Model.DeveloperName).Count() > 0)
            {
                return PartialView(Model);
            }
            if (ModelState.IsValid)
            {
               
                if (Model.Id == -1)
                {
                    Models.Developer NewDeveloper = new Models.Developer();
                    NewDeveloper.DeveloperName = Model.DeveloperName;
                    Context.Developers.Add(NewDeveloper);
                    Context.SaveChanges();
                }
                else
                {
                    Context.Developers.Find(Model.Id).DeveloperName = Model.DeveloperName;
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
            return PartialView(Context.Developers.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(GamesShop.Models.Developer Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Developers.Remove(Context.Developers.Find(Model.Id));
            Context.SaveChanges();
            return PartialView(Model);
        }
    }
}