using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrmanFakultesi.Controllers
{
    public class AdminController : Controller
    {
        ofContext db = new ofContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ayarlar()
        {
            Ayarlar a = db.Ayarlar.Where(x => x.ayarID == 1).FirstOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult ayarDuzenle(Ayarlar A)
        {
            Ayarlar a = db.Ayarlar.Where(x => x.ayarID == 1).FirstOrDefault();
            a.MaxsaatlikRandevuKisiSayisi = A.MaxsaatlikRandevuKisiSayisi;
            db.SaveChanges();
            return RedirectToAction("Ayarlar");
        }

        [HttpPost]
        public ActionResult Ayarlar(Ayarlar ayar)
        {
            Ayarlar a = db.Ayarlar.Where(x => x.ayarID == 1).FirstOrDefault();
            a.MaxsaatlikRandevuKisiSayisi = ayar.MaxsaatlikRandevuKisiSayisi;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult bolumTanimi()
        {
            var blm = db.BolumTanimi.ToList();
            return View(blm);
        }

        [HttpPost]
        public ActionResult bolumTanimi(BolumTanimi b)
        {
            db.BolumTanimi.Add(b);
            db.SaveChanges();
            var blm = db.BolumTanimi.ToList();
            return View(blm);
        }


    }
}