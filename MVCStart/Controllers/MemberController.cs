using MVCStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCStart.Controllers
{
    public class MemberController : Controller
    {
        List<string> provinces = new List<string>()
        {
            "Bangkok",
            "Chonburi",
            "Phuket",
            "Nontaburi",
            "Chiangmai"
        };


        // GET: Member
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewData["provincesList"] = new SelectList(provinces);
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterModel m)
        {
            ViewData["provincesList"] = new SelectList(provinces);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<b>Name</b> : {0}<br>",m.Name);
            sb.AppendFormat("<b>E-mail</b> : {0}<br>", m.Email);
            sb.AppendFormat("<b>Password</b> : {0}<br>", m.Password);
            sb.AppendFormat("<b>Confirm Password</b> : {0}<br>", m.ConfirmPassword);
            sb.AppendFormat("<b>Gender</b> : {0}<br>", m.Gender);
            sb.AppendFormat("<b>Newsletter</b> : {0}<br>", m.Newsletter);
            sb.AppendFormat("<b>Address</b> : {0}<br>", m.Address);
            sb.AppendFormat("<b>Province</b> : {0}<br>", m.Province);

            ViewBag.Data = sb.ToString();
            return View();
        }

    }
}