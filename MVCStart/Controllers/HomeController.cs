using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[NonAction]
        [ActionName("ContactUs")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View("Contact");
        }

        public ActionResult Webboard(string productName,string productID)
        {
            ViewBag.Message = "Hello Webboard!";
            ViewBag.productName = productName;
            ViewBag.productID = productID;
            return View();
        }
    }
}