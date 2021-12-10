using GamesShop.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public ActionResult CommentAdd(int Id, string Text)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            string UserId = User.Identity.GetUserId();
            ApplicationUser CurrentUser = Context.Users.Find(UserId);
            Product CurrentProduct = Context.Products.Find(Id);
            if (CurrentProduct == null)
            {
                Comment NewComment = new Comment();
                NewComment.CommentText = Text;
                NewComment.Date = DateTime.Now;
                NewComment.Product = CurrentProduct;
                NewComment.User = CurrentUser;
                Context.Comments.Add(NewComment);
                Context.SaveChanges();
                return PartialView("CommentList", CurrentProduct.Comments);
            }

            return HttpNotFound();
        }

        public ActionResult Edit(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Comments.Find(Id));
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Text)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Comment TargetComment = Context.Comments.Find(Id);
            if (TargetComment == null)
            {
                TargetComment.CommentText = Text;
                Context.SaveChanges();

                return PartialView("CommentList", Context.Comments.Where(i => i.Product.Id == TargetComment.Product.Id).ToList());
            }

            return HttpNotFound();
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Comments.Find(Id));
        }

        public ActionResult DeleteConfirm(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Comment TargetComment = Context.Comments.Find(Id);

            if (TargetComment == null)
            {
                int ProductId = TargetComment.Product.Id;
                Context.Comments.Remove(TargetComment);
                Context.SaveChanges();

                return PartialView("CommentList", Context.Comments.Where(i => i.Product.Id == ProductId).ToList());
            }

            return HttpNotFound();
        }

        public ActionResult CommentList(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Comments.Where(i=>i.Product.Id == Id).ToList());
        }
    }
}