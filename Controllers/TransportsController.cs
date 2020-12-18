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
    public class TransportsController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: Transports
        public ActionResult Index()
        {
            var transports = db.Transports.Include(t => t.Order).Include(t => t.Route);
            return View(transports.ToList());
        }

        // GET: Transports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create()
        {
            ViewBag.TransportID = new SelectList(db.Orders, "OrderID", "Status");
            ViewBag.TransportID = new SelectList(db.Routes, "RouteID", "RouteID");
            return View();
        }

        // POST: Transports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransportID,RouteID,TruckID,EmployeeID,OrderID,DepartureDay")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Transports.Add(transport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportID = new SelectList(db.Orders, "OrderID", "Status", transport.TransportID);
            ViewBag.TransportID = new SelectList(db.Routes, "RouteID", "RouteID", transport.TransportID);
            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportID = new SelectList(db.Orders, "OrderID", "Status", transport.TransportID);
            ViewBag.TransportID = new SelectList(db.Routes, "RouteID", "RouteID", transport.TransportID);
            return View(transport);
        }

        // POST: Transports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransportID,RouteID,TruckID,EmployeeID,OrderID,DepartureDay")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportID = new SelectList(db.Orders, "OrderID", "Status", transport.TransportID);
            ViewBag.TransportID = new SelectList(db.Routes, "RouteID", "RouteID", transport.TransportID);
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transport transport = db.Transports.Find(id);
            db.Transports.Remove(transport);
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
