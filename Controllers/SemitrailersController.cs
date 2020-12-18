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
    public class SemitrailersController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: Semitrailers
        public ActionResult Index()
        {
            return View(db.Semitrailers.ToList());
        }

        // GET: Semitrailers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semitrailer semitrailer = db.Semitrailers.Find(id);
            if (semitrailer == null)
            {
                return HttpNotFound();
            }
            return View(semitrailer);
        }

        // GET: Semitrailers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semitrailers/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemitrailerID,RegistrationNr,Capacity")] Semitrailer semitrailer)
        {
            if (ModelState.IsValid)
            {
                db.Semitrailers.Add(semitrailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semitrailer);
        }

        // GET: Semitrailers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semitrailer semitrailer = db.Semitrailers.Find(id);
            if (semitrailer == null)
            {
                return HttpNotFound();
            }
            return View(semitrailer);
        }

        // POST: Semitrailers/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemitrailerID,RegistrationNr,Capacity")] Semitrailer semitrailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semitrailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semitrailer);
        }

        // GET: Semitrailers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semitrailer semitrailer = db.Semitrailers.Find(id);
            if (semitrailer == null)
            {
                return HttpNotFound();
            }
            return View(semitrailer);
        }

        // POST: Semitrailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semitrailer semitrailer = db.Semitrailers.Find(id);
            db.Semitrailers.Remove(semitrailer);
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
