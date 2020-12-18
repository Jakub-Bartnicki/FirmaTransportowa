using FirmaTransportowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FirmaTransportowa.Controllers
{
    public class ClientProductsController : Controller
    {
        private DAL.TransportContext db = new DAL.TransportContext();
        // GET: ClientProduct
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: ClientProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    }
}
