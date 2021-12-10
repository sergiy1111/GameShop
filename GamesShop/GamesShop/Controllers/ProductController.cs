using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Input(int? Id)
        {
            ProductInputViewModel viewModel = new ProductInputViewModel();
            viewModel.Id = Id.Value;
            viewModel.OperatingSystems = new List<int>();
            viewModel.Categories = new List<int>();
            viewModel.FilesForEdit = new List<string>();
            viewModel.Keys = new List<string>();

            if (Id.Value == -1)
            {
                viewModel.Name = "";
                viewModel.Description = "";
                viewModel.Day = 0;
                viewModel.Month = 0;
                viewModel.Year = 0;
                viewModel.Price = 0;
                viewModel.Raiting = 0;
                viewModel.Developer = 0;
                viewModel.Publisher = 0;
                viewModel.Processor = "";
                viewModel.RAM = "";
                viewModel.DriveSpace = "";
                viewModel.VideoCard = "";
                viewModel.Other = "";

            }
            else
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                Product Product = Context.Products.Find(Id.Value);               
                viewModel.Name = Product.ProductName;
                viewModel.Description = Product.Description;
                viewModel.Day = Product.ReleaseDate.Day;
                viewModel.Month = Product.ReleaseDate.Month;
                viewModel.Year = Product.ReleaseDate.Year;
                viewModel.Price = Product.Price;
                viewModel.Raiting = Product.Rating;
                viewModel.Developer = Product.Developer.Id;
                viewModel.Publisher = Product.Publisher.Id;

                foreach(var Item in Product.Categories)
                {
                    viewModel.Categories.Add(Item.Id);
                }
                foreach (var Item in Product.Files)
                {
                    viewModel.FilesForEdit.Add(Item.FileName);
                }

                viewModel.Processor = Product.Processor;
                viewModel.RAM = Product.RAM;
                viewModel.DriveSpace = Product.DriveSpace;
                viewModel.VideoCard = Product.VideoCard;
                viewModel.Other = Product.Other;

                foreach (var Item in Product.OperatingSystems)
                {
                    viewModel.OperatingSystems.Add(Item.Id);
                }

                foreach (var Item in Product.Keys)
                {
                    viewModel.Keys.Add(Item.KeyString);
                }
            }
            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult Input(ProductInputViewModel ViewModel)
        {
            if(ViewModel.Day == -1 || ViewModel.Month == -1 || ViewModel.Year == -1)
            {
                ModelState.AddModelError("Day", "Дата введена невірно");
            }
            if(ModelState.IsValid)
            {
                ApplicationDbContext Context = new ApplicationDbContext();
                if(ViewModel.Id == -1)
                {
                    Product NewProduct = new Product();
                    NewProduct.ProductName = ViewModel.Name;
                    NewProduct.Description = ViewModel.Description;
                    NewProduct.ReleaseDate = new DateTime(ViewModel.Year, ViewModel.Month, ViewModel.Day);
                    NewProduct.Price = ViewModel.Price;
                    NewProduct.Rating = ViewModel.Raiting;
                    NewProduct.Developer = Context.Developers.Find(ViewModel.Developer);
                    NewProduct.Publisher = Context.Publishers.Find(ViewModel.Publisher);

                    foreach (var Item in ViewModel.Categories)
                    {
                        NewProduct.Categories.Add(Context.Categories.Find(Item));
                    }

                 
                    if (ViewModel.Files.Count() != 0)
                    {
                        List<Models.File> Files = new List<Models.File>();
                        string FileName;
                        int Counter = (Context.Files.Count() == 0 ? 1 : Context.Files.ToList().LastOrDefault().Id + 1);
                        foreach(var Item in ViewModel.Files)
                        {
                            FileName = "NoImage.png";
                            if (Item != null)
                            {
                                FileName = Counter + NewProduct.ProductName + ".png";
                                Item.SaveAs(Server.MapPath("~/Files/" + FileName));

                                Files.Add(new Models.File() { FileName = FileName, Product = NewProduct });
                            }
                            Counter++;
                        }
                        NewProduct.Files.AddRange(Files);
                    }

                    NewProduct.Processor = ViewModel.Processor;
                    NewProduct.RAM = ViewModel.RAM;
                    NewProduct.VideoCard = ViewModel.VideoCard;
                    NewProduct.DriveSpace = ViewModel.DriveSpace;
                    NewProduct.Other = ViewModel.Other;

                    foreach (var Item in ViewModel.OperatingSystems)
                    {
                        NewProduct.OperatingSystems.Add(Context.OperatingSystems.Find(Item));
                    }

                    foreach (var Item in ViewModel.Keys)
                    {
                        NewProduct.Keys.Add(new Models.Key() { KeyString = Item, IsUsed = false});
                    }

                    Context.Products.Add(NewProduct);
                    Context.SaveChanges();
                    return PartialView(ViewModel);
                }
                else
                {
                    Product ProductForEdit = Context.Products.Find(ViewModel.Id);
                    ProductForEdit.ProductName = ViewModel.Name;
                    ProductForEdit.Description = ViewModel.Description;
                    ProductForEdit.ReleaseDate = new DateTime(ViewModel.Year, ViewModel.Month, ViewModel.Day);
                    ProductForEdit.Price = ViewModel.Price;
                    ProductForEdit.Rating = ViewModel.Raiting;
                    ProductForEdit.Developer = Context.Developers.Find(ViewModel.Developer);
                    ProductForEdit.Publisher = Context.Publishers.Find(ViewModel.Publisher);

                    if (ViewModel.Categories != null)
                    {
                        foreach (var Item in ViewModel.Categories)
                        {
                            ProductForEdit.Categories.Add(Context.Categories.Find(Item));
                        }
                    }

                    if (ViewModel.Files != null)
                    {
                        if (ViewModel.Files.Count() != 0)
                        {
                            List<Models.File> Files = new List<Models.File>();
                            string FileName;
                            int Counter = (Context.Files.Count() == 0 ? 1 : Context.Files.ToList().LastOrDefault().Id + 1);
                            foreach (var Item in ViewModel.Files)
                            {
                                FileName = "NoImage.png";
                                if (Item != null)
                                {
                                    FileName = Counter + ProductForEdit.ProductName + ".png";
                                    Item.SaveAs(Server.MapPath("~/Files/" + FileName));

                                    Files.Add(new Models.File() { FileName = FileName, Product = ProductForEdit });
                                }
                                Counter++;
                            }
                            ProductForEdit.Files.AddRange(Files);
                        }
                    }

                    ProductForEdit.Processor = ViewModel.Processor;
                    ProductForEdit.RAM = ViewModel.RAM;
                    ProductForEdit.VideoCard = ViewModel.VideoCard;
                    ProductForEdit.DriveSpace = ViewModel.DriveSpace;
                    ProductForEdit.Other = ViewModel.Other;

                    if(ViewModel.OperatingSystems != null)
                    {
                        foreach (var Item in ViewModel.OperatingSystems)
                        {
                            ProductForEdit.OperatingSystems.Add(Context.OperatingSystems.Find(Item));
                        }
                    }
                    if (ViewModel.Keys != null)
                    {
                        foreach (var Item in ViewModel.Keys)
                        {
                            ProductForEdit.Keys.Add(new Models.Key() { KeyString = Item, IsUsed = false });
                        }
                    }
                    Context.SaveChanges();
                    return PartialView(ViewModel);
                }
            }
            return PartialView(ViewModel);
        }

        public ActionResult Category()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Categories.ToList());
        }

        public ActionResult File()
        {
            return PartialView();
        }

        public ActionResult OperatingSystem()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.OperatingSystems.ToList());
        }

        public ActionResult Key()
        {
            return PartialView();
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Products.Find(Id));
        }

        public ActionResult Info(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Products.Find(Id));
        }

        [HttpPost]
        public ActionResult Delete(Product Model)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Product DeleteProduct = Context.Products.Find(Model.Id);
            foreach (var item in DeleteProduct.Files.ToArray())
            {
                System.IO.File.Delete(Server.MapPath("~/Files/" + item));
                Context.Files.Remove(Context.Files.Find(item.Id));
            }
            Context.Comments.Where(i => i.Product.Id == DeleteProduct.Id).ToList().Clear();
            Context.Keys.Where(i => i.Product.Id == DeleteProduct.Id).ToList().Clear();

            DeleteProduct.Comments.Clear();
            DeleteProduct.Files.Clear();
            DeleteProduct.Categories.Clear();
            DeleteProduct.OperatingSystems.Clear();
            DeleteProduct.Keys.Clear();

            Context.Products.Remove(DeleteProduct);
            Context.SaveChanges();
            return PartialView(Model);
        }

        public ActionResult DeleteCategory(int Id, int ModelId)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Products.Find(ModelId).Categories.Remove(Context.Categories.Find(Id));
            Context.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult DeleteFile(string File, int ModelId)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Models.File SelectedFile = Context.Files.Where(i => i.FileName.Equals(File)).FirstOrDefault();
            Context.Products.Find(ModelId).Files.Remove(SelectedFile);
            System.IO.File.Delete(Server.MapPath("~/Files/" + SelectedFile.FileName));
            Context.Files.Remove(SelectedFile);
            
            Context.SaveChanges();
            return RedirectToAction("File");
        }

        public ActionResult DeleteOS(int Id, int ModelId)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Products.Find(ModelId).OperatingSystems.Remove(Context.OperatingSystems.Find(Id));
            Context.SaveChanges();
            return RedirectToAction("OperatingSystem");
        }
        public ActionResult DeleteKey(int Id, int ModelId)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Context.Products.Find(ModelId).Keys.Remove(Context.Keys.Find(Id));
            Context.Keys.Remove(Context.Keys.Find(Id));
            Context.SaveChanges();
            return RedirectToAction("Key");
        }
    }
}