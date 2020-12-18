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
    public class ManagersController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: Managers
        public ActionResult Index()
        {
            var managers = db.Managers.Include(m => m.Account).Include(m => m.PersonDetails);
            return View(managers.ToList());
        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manager manager)
        {   
            var emailCheck = db.Accounts.FirstOrDefault(s => s.Email == manager.Account.Email);
            var loginCheck = db.Accounts.FirstOrDefault(s => s.Login == manager.Account.Login);
            if (emailCheck != null)
            {
                ViewBag.emailError = "Email already exists";
                return View();
            }
            else if (loginCheck != null)
            {
                ViewBag.loginError = "Choose another login";
                return View();
            }

            manager.Account.PasswordHash = HomeController.GetMD5(manager.Account.PasswordHash);
            manager.Account.CreationDate = DateTime.Now;
            manager.Account.Type = "manager";
            db.Configuration.ValidateOnSaveEnabled = false;

            var account = manager.Account;
            var personalDetails = manager.PersonDetails;
            var address = manager.PersonDetails.Address;

            db.Managers.Add(manager);
            manager.PersonDetailsID = 0;
            manager.AccountID = 0;
            manager.PersonDetails.AddressID = 0;
            db.SaveChanges();
            manager.PersonDetailsID = personalDetails.PersonDetailsID;
            manager.AccountID = account.AccountID;
            manager.PersonDetails.AddressID = address.AddressID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }

            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manager manager)
        {
            var currentManager = db.Managers.FirstOrDefault(p => p.ManagerID == manager.ManagerID);
            if (currentManager == null)
                return HttpNotFound();

            currentManager.Account.Login = manager.Account.Login;
            currentManager.Account.Email = manager.Account.Email;
            currentManager.PersonDetails.FirstName = manager.PersonDetails.FirstName;
            currentManager.PersonDetails.LastName = manager.PersonDetails.LastName;
            currentManager.PersonDetails.Phone = manager.PersonDetails.Phone;
            currentManager.PersonDetails.Address.Country = manager.PersonDetails.Address.Country;
            currentManager.PersonDetails.Address.City = manager.PersonDetails.Address.City;
            currentManager.PersonDetails.Address.PostalCode = manager.PersonDetails.Address.PostalCode;
            currentManager.PersonDetails.Address.Street = manager.PersonDetails.Address.Street;

            db.Entry(currentManager).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager manager = db.Managers.Find(id);
            db.Managers.Remove(manager);
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
