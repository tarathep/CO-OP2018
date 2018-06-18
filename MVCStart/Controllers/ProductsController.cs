using MVCStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCStart.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1 , Name ="ASP.NET MVC5" , Price = 225.50},
            new Product { Id = 2 , Name ="Bootstrap" , Price = 199},
            new Product { Id = 3 , Name ="Java" , Price = 205.50},
            new Product { Id = 4 , Name ="Css" , Price = 455.50},
            new Product { Id = 5 , Name ="HTML" , Price = 1220.50}
        };

        // GET: Products
        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);
            return View("ProductDetails", product);
        }

        public ActionResult showViewData()
        {
            ViewData["ListBook"] = new List<string>()
            {
                "C#.NET",
                "VB.NET",
                "C++",
                "Java"
            };

            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Create Date : {0}<br>" ,frm["CreateDate"]);
            sb.AppendFormat("Date Time: {0}<br>", frm["DateTime"]);
            sb.AppendFormat("Month: {0}<br>", frm["Month"]);
            sb.AppendFormat("Week: {0}<br>", frm["Week"]);
            sb.AppendFormat("Time: {0}<br>", frm["Time"]);
            sb.AppendFormat("Color: {0}<br>", frm["Color"]);

            ViewBag.Data = sb.ToString();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }


    }
}