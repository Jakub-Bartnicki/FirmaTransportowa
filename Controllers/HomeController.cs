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
        private DAL.TransportContext _db = new DAL.TransportContext();
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

        //GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _account)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Accounts.FirstOrDefault(s => s.Email == _account.Email);
                if (check == null)
                {
                    _account.PasswordHash = GetMD5(_account.PasswordHash);
                    _account.CreationDate = DateTime.Now;
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Accounts.Add(_account);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
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
        public ActionResult Login(string email, string passwordHash)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(passwordHash);
                var data = _db.Accounts.Where(s => s.Email.Equals(email) && s.PasswordHash.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Login"] = data.FirstOrDefault().Login;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["AccountID"] = data.FirstOrDefault().AccountID;
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


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
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