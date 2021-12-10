using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesShop.Controllers
{
    public class TestingCodeController : Controller
    {
        // GET: TestingCode
        public ActionResult Index()
        {
            return View();
        }
        public int Test2(int x, int y)
        {
            return x + y;
        }
        public int Test3(int x, int y)
        {
            return x - y;
        }
        public int Test4(int x, int y)
        {
            return (int)((x*y) +  Math.Pow(x,2));
        }
        public ActionResult Test5()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}