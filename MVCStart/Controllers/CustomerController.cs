using MVCStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStart.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer { CustomersID = "1", FullName ="Uthamat" ,Address ="bangkok"},
            new Customer { CustomersID = "2", FullName ="Patta" ,Address ="nan"}
        };

        // GET: Customer
        public ActionResult Index()
        {
            var query = (from c in customers
                         where c.CustomersID == "1"
                         select c).FirstOrDefault();
            ViewBag.Info = query.CustomersID + " " + query.FullName;

            var queryLambda = customers.Where(c => c.CustomersID == "1").FirstOrDefault();
            ViewBag.InfoLambda = queryLambda.CustomersID + " " + queryLambda.Address;

            return View();
        }
    }
}