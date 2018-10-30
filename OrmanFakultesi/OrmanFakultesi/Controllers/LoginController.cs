using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrmanFakultesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        ofContext db = new ofContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string eposta , string sifre)
        {
            Kullanici user = db.Kullanici.Where(x => x.mail == eposta && x.sifre == sifre).SingleOrDefault();
            if(user==null)
            {
                ViewBag.Sonuc = "Kullanıcı Bulunamadı";
                return View();
            }
            else
            {
                Session["Kullanici"] = user; // kullanıcı Bulundu.
                return RedirectToAction("Admin", "Index");
            }

        }
    }
}