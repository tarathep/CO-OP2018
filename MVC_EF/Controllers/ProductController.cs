using MVC_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF.Controllers
{
    public class ProductController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult ProductJson()
        {
            var data = db.Products.ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        // GET: Product
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = db.Products.Find(id);

            if (data == null) return HttpNotFound();

            return View(data);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            //sender id find catename show
            ViewData["CategoryIdList"] = new SelectList(db.Categories,"CategoryID","CategoryName");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products product)
        {
            try
            {
                //SAVE INTO DB
                db.Products.Add(product);//add = insert do not update!!
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewData["CategoryIdList"] = new SelectList(db.Categories, "CategoryID", "CategoryName");
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var data = db.Products.Find(id);
            if (data == null) return HttpNotFound();
           
            return View(data);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products product)
        {
            //ViewData["CategoryIdList"] = new SelectList(db.Categories, "CategoryID", "CategoryName");
            try
            {
                // TODO: Add update logic here
                var data = db.Products.SingleOrDefault(u => u.ProductID == product.ProductID);
                data.ProductID = product.ProductID;
                data.ProductName = product.ProductName;
                data.SupplierID = product.SupplierID;
                data.CategoryID = product.CategoryID;
                data.QuantityPerUnit = product.QuantityPerUnit;
                data.UnitPrice = product.UnitPrice;
                data.UnitsInStock = product.UnitsInStock;
                data.UnitsOnOrder = product.UnitsOnOrder;
                data.ReorderLevel = product.ReorderLevel;
                data.Discontinued = product.Discontinued;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
           
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var data = db.Products.Find(id);

            if (data == null) return HttpNotFound();

            return View(data);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Products products = db.Products.Find(id);
                db.Products.Remove(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
