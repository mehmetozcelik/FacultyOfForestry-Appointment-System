using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrmanFakultesi.Controllers
{
    public class UyeController : Controller
    {
        ofContext db = new ofContext();
        // GET: Uye
        public ActionResult Index() // Uye Giriş
        {
            if (Session["Kullanici"] !=null)
            {
                return RedirectToAction("UyeBilgiler");
            }
            return View();
        }

        [HttpPost]
        public ActionResult UyeGiris(string mail,string sifre)
        {
            Uye uye = db.Uye.Where(x => x.mail == mail && x.sifre == sifre).SingleOrDefault();

            if (uye != null)
            {
                Session["Kullanici"]=uye;
                return RedirectToAction("UyeBilgiler");
            }
            else
            {
                TempData["UyeGirisHata"] = "Girdiğiniz Bilgilere ait bir üye bulunamadı.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UyeBilgiler()
        {

            Uye uye = (Uye)Session["Kullanici"];

            return View(db.Randevu.Where(x => x.uyeID == uye.uyeID).ToList());
        }

        [HttpGet]
        public ActionResult Uyelik()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Uyelik(Uye uye)
        {
            Uye qUser = db.Uye.Where(x => x.mail == uye.mail || x.tel == uye.tel || x.tc==uye.tc).SingleOrDefault();
            if (qUser !=null)
            {
                ViewBag.qUserHata = "Girdiğiniz mail veya telefon veya T.C. Kimlik numarası ile sisteme kayıtlı kullanıcı bulunmaktadır.";
                return View();
            }
            else
            {
                db.Uye.Add(uye);
                db.SaveChanges();
                Uye yeni = db.Uye.Where(x => x.mail == uye.mail).SingleOrDefault();
                yeni.onay = true;
                db.SaveChanges();
                if (yeni != null)
                {
                    Session["Kullanici"] = yeni;
                    return RedirectToAction("UyeBilgiler");
                }
            }
            return View();
        }
    }
}