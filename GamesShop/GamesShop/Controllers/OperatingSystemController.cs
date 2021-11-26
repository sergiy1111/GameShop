using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    public class OperatingSystemController : Controller
    {

        // GET: Default
        public ActionResult Input(int? Id)
        {
            Models.OperatingSystem Model = new Models.OperatingSystem();
            if(Id.Value == -1)
            {
                Model.Id = -1;
                Model.Name = "";
            }
            else
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Model.Id = Id.Value;
                Model.Name = Context.OperatingSystems.Find(Id.Value).Name;
            }
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult Input(GamesShop.Models.OperatingSystem Model)
        {
            if(ModelState.IsValid)
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                if (Model.Id == -1)
                {
                    Models.OperatingSystem NewOS = new Models.OperatingSystem();
                    NewOS.Name = Model.Name;
                    Context.OperatingSystems.Add(NewOS);
                    Context.SaveChanges();
                }
                else
                {
                    Context.OperatingSystems.Find(Model.Id).Name = Model.Name;
                    Context.SaveChanges();
                }
                return PartialView(Model);
            }
            return PartialView(Model);
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.OperatingSystems.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(GamesShop.Models.OperatingSystem Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.OperatingSystems.Remove(Context.OperatingSystems.Find(Model.Id));
            Context.SaveChanges();
            return PartialView(Model);
        }
    }
}