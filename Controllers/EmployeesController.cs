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
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            var emailCheck = db.Accounts.FirstOrDefault(s => s.Email == employee.Account.Email);
            var loginCheck = db.Accounts.FirstOrDefault(s => s.Login == employee.Account.Login);
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

            employee.Account.PasswordHash = HomeController.GetMD5(employee.Account.PasswordHash);
            employee.Account.CreationDate = DateTime.Now;
            employee.Account.Type = "employee";
            db.Configuration.ValidateOnSaveEnabled = false;

            var newEmployee = new Employee();
            var account = employee.Account;
            var personalDetails = employee.PersonDetails;
            var address = employee.PersonDetails.Address;
            db.Addresses.Add(address);
            db.SaveChanges();
            personalDetails.AddressID = address.AddressID;
            personalDetails.Address = address;
            db.PersonDetails.Add(personalDetails);
            db.SaveChanges();
            db.Accounts.Add(account);
            db.SaveChanges();
            newEmployee.AccountID = account.AccountID;
            newEmployee.PersonDetailsID = personalDetails.PersonDetailsID;
            newEmployee.Account = account;
            newEmployee.PersonDetails = personalDetails;
            newEmployee.Manager = db.Managers.Find(employee.ManagerID);
                
            db.Employees.Add(newEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
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
