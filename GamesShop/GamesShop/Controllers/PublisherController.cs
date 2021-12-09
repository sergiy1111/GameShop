using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Input(int? Id)
        {
            Publisher Model = new Models.Publisher();
            if (Id.Value == -1)
            {
                Model.Id = -1;
                Model.PublisherName = "";
            }
            else
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Model.Id = Id.Value;
                Model.PublisherName = Context.Publishers.Find(Id.Value).PublisherName;
            }
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult Input(GamesShop.Models.Publisher Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            if (Context.Publishers.Where(i => i.PublisherName == Model.PublisherName).Count() > 0)
            {
                return PartialView(Model);
            }
            if (ModelState.IsValid)
            {
                if (Model.Id == -1)
                {
                    Models.Publisher NewPublisher = new Models.Publisher();
                    NewPublisher.PublisherName = Model.PublisherName;
                    Context.Publishers.Add(NewPublisher);
                    Context.SaveChanges();
                }
                else
                {
                    Context.Publishers.Find(Model.Id).PublisherName = Model.PublisherName;
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
            return PartialView(Context.Publishers.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(GamesShop.Models.Publisher Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Publishers.Remove(Context.Publishers.Find(Model.Id));
            Context.SaveChanges();
            return PartialView(Model);
        }
    }
}