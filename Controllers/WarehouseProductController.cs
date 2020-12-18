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

namespace FirmaTransportowa.Controllers
{
    public class WarehouseProductController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: WarehouseProduct
        public ActionResult Index()
        {
            var warehouseProducts = db.WarehouseProducts.Include(w => w.Product).Include(w => w.Warehouse);
            return View(warehouseProducts.ToList());
        }

        // GET: WarehouseProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct warehouseProduct = db.WarehouseProducts.Find(id);
            if (warehouseProduct == null)
            {
                return HttpNotFound();
            }
            return View(warehouseProduct);
        }

        // GET: WarehouseProduct/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseID");
            return View();
        }

        // POST: WarehouseProduct/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WarehouseProductID,WarehouseID,ProductID,QuantityInStock,MaxQuantity")] WarehouseProduct warehouseProduct)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseProducts.Add(warehouseProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", warehouseProduct.ProductID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseID", warehouseProduct.WarehouseID);
            return View(warehouseProduct);
        }

        // GET: WarehouseProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct warehouseProduct = db.WarehouseProducts.Find(id);
            if (warehouseProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", warehouseProduct.ProductID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseID", warehouseProduct.WarehouseID);
            return View(warehouseProduct);
        }

        // POST: WarehouseProduct/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WarehouseProductID,WarehouseID,ProductID,QuantityInStock,MaxQuantity")] WarehouseProduct warehouseProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", warehouseProduct.ProductID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseID", warehouseProduct.WarehouseID);
            return View(warehouseProduct);
        }

        // GET: WarehouseProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseProduct warehouseProduct = db.WarehouseProducts.Find(id);
            if (warehouseProduct == null)
            {
                return HttpNotFound();
            }
            return View(warehouseProduct);
        }

        // POST: WarehouseProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseProduct warehouseProduct = db.WarehouseProducts.Find(id);
            db.WarehouseProducts.Remove(warehouseProduct);
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
    }
}
