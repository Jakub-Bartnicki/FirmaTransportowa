using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FirmaTransportowa.DAL;
using FirmaTransportowa.Models;
using FirmaTransportowa.Controllers;


namespace FirmaTransportowa.Controllers
{
    public class WarehouseProductsController : Controller
    {

        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: WarehouseProducts
        public ActionResult Index()
        {
            var prooducts = db.WarehouseProducts.Include(e => e.Warehouse).Include(e => e.Product);
            return View(prooducts.ToList());

        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct product = db.WarehouseProducts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct product = db.WarehouseProducts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "Name", "Description", "BuyPrice", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Warehouses, "WarehouseID", "AdressID", product.ProductID);
            return View(product);
        }
        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarehouseID, AdressID")] WarehouseProduct product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "Name", "Description", "BuyPrice", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Warehouses, "WarehouseID", "AdressID", product.ProductID);
            return View(product);
        }
        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct product = db.WarehouseProducts.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseProduct product = db.WarehouseProducts.Find(id);
            db.WarehouseProducts.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(WarehouseProduct product)
        {

            var product2 = product.Product;
            var warehouse = product.Warehouse;
            var address = product.Warehouse.Address;
            db.WarehouseProducts.Add(product);
            product.WarehouseID = warehouse.WarehouseID;
            product.ProductID = product2.ProductID;
            product.Warehouse.AddressID = address.AddressID;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}