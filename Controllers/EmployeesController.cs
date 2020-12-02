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
    public class EmployeesController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Account).Include(e => e.Manager).Include(e => e.PersonDetails);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Accounts, "AccountID", "Login");
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerID");
            ViewBag.EmployeeID = new SelectList(db.PersonDetails, "PersonDetailsID", "FirstName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,ManagerID,PersonDetailsID,AccountID,JobTitle,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Accounts, "AccountID", "Login", employee.EmployeeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerID", employee.ManagerID);
            ViewBag.EmployeeID = new SelectList(db.PersonDetails, "PersonDetailsID", "FirstName", employee.EmployeeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Accounts, "AccountID", "Login", employee.EmployeeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerID", employee.ManagerID);
            ViewBag.EmployeeID = new SelectList(db.PersonDetails, "PersonDetailsID", "FirstName", employee.EmployeeID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,ManagerID,PersonDetailsID,AccountID,JobTitle,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Accounts, "AccountID", "Login", employee.EmployeeID);
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "ManagerID", employee.ManagerID);
            ViewBag.EmployeeID = new SelectList(db.PersonDetails, "PersonDetailsID", "FirstName", employee.EmployeeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
