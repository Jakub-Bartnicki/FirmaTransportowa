using FirmaTransportowa.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace FirmaTransportowa.Controllers
{
    public class HomeController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["AccountID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        
        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var emailCheck = db.Accounts.FirstOrDefault(s => s.Email == customer.Account.Email);
                var loginCheck = db.Accounts.FirstOrDefault(s => s.Login == customer.Account.Login);
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
                else
                {
                    customer.Account.PasswordHash = GetMD5(customer.Account.PasswordHash);
                    customer.Account.CreationDate = DateTime.Now;
                    customer.Account.Type = "customer";
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var account = customer.Account;
                    var personalDetails = customer.PersonDetails;
                    var address = customer.PersonDetails.Address;


                    db.Customers.Add(customer);
                    customer.PersonDetailsID = personalDetails.PersonDetailsID;
                    customer.AccountID = account.AccountID;
                    customer.PersonDetails.AddressID = address.AddressID;
                    db.SaveChanges();
                    customer.PersonDetailsID = personalDetails.PersonDetailsID;
                    customer.AccountID = account.AccountID;
                    customer.PersonDetails.AddressID = address.AddressID;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string passwordHash)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(passwordHash);
                var data = db.Accounts.Where(s => s.Login.Equals(login) && s.PasswordHash.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Login"] = data.FirstOrDefault().Login;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["AccountID"] = data.FirstOrDefault().AccountID;
                    Session["Type"] = data.FirstOrDefault().Type;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        // Logout
        public ActionResult Logout()
        {
            Session.Clear(); // remove session
            return RedirectToAction("Login");
        }


        // create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}