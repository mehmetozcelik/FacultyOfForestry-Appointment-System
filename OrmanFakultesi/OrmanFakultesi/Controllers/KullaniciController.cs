using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrmanFakultesi.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici

        ofContext db = new ofContext();

        //------------------------------------ Kullanıcı İşlemleri Başlangıç ------------------------------------//

        [HttpGet]
        public ActionResult Index() // Kullanici Listesi
        {
            return View(db.Kullanici.ToList());
        }

        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            var yetki = db.Yetki.ToList();
            var yetkiler = new SelectList(yetki, "yetkiID", "adi");
            return View(yetkiler);
        }

        [HttpPost]
        public ActionResult KullaniciEkle(Kullanici k) 
        {
            db.Kullanici.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KullaniciSil(int id)
        {
            Kullanici k = db.Kullanici.Where(x => x.kullaniciID == id).SingleOrDefault();
            if (k == null)
            {
                return Json(false);
            }
            else
            {
                db.Kullanici.Remove(k);
                db.SaveChanges();
                return Json(true);
            }
        }

        [HttpGet]
        public ActionResult KullaniciDuzenle(int id)
        {
            Kullanici k = db.Kullanici.Where(x => x.kullaniciID == id).SingleOrDefault();

            if (k == null)
            {
                return RedirectToAction("Admin", "Hata1");
            }
            else
            {
                var yetkiler = db.Yetki.ToList();
                ViewBag.yetkiler = new SelectList(yetkiler, "yetkiID", "adi");
                return View(k);
            }
        }

        [HttpPost]
        public ActionResult KullaniciDuzenle(Kullanici k)
        {
            Kullanici kl = db.Kullanici.Where(x => x.kullaniciID == k.kullaniciID).SingleOrDefault();
            kl.adi = k.adi;
            kl.soyadi = k.soyadi;
            kl.mail = k.mail;
            kl.sifre = k.sifre;
            kl.yetkiID = k.yetkiID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //------------------------------------ Kullanıcı İşlemleri Son ------------------------------------//



        //------------------------------------ Yetki İşlemleri Başlangıç ------------------------------------//

        [HttpGet]
        public ActionResult YetkiListesi()
        {
            ViewBag.yl = db.Yetki.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult YetkiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YetkiEkle(Yetki y)
        {
            db.Yetki.Add(y);
            db.SaveChanges();

            return RedirectToAction("YetkiListesi");
        }

        public ActionResult YetkiSil(int id)
        {
            Yetki y = db.Yetki.Where(x => x.yetkiID == id).SingleOrDefault();
            if (y==null)
            {
                return Json(false);
            }
            else
            {
                db.Yetki.Remove(y);
                db.SaveChanges();
                return Json(true);
            }
        }

        [HttpGet]
        public ActionResult YetkiDuzenle(int id)
        {
            Yetki y = db.Yetki.Where(x => x.yetkiID == id).SingleOrDefault();

            if(y==null)
            {
                return RedirectToAction("Admin", "Hata1");
            }
            else
            {
                return View(y);
            }
        }

        [HttpPost]
        public ActionResult YetkiDuzenle(Yetki y)
        {
           Yetki yt = db.Yetki.Where(x => x.yetkiID == y.yetkiID).SingleOrDefault();

            yt.adi = y.adi;
            yt.aciklama = y.aciklama;
            db.SaveChanges();
            return RedirectToAction("YetkiListesi");         
        }


        //------------------------------------ Yetki İşlemleri Son ------------------------------------//

        //------------------------------------ Sergi Sorumlusu İşlemleri Başlangıç --------------------//

        public ActionResult SergiSorumlusuListesi()
        {
            return View(db.SergiSorumlulari.ToList());
        }

        [HttpGet]
        public ActionResult sorumluEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sorumluEkle(SergiSorumlulari s)
        {
            db.SergiSorumlulari.Add(s);
            db.SaveChanges();
            return RedirectToAction("SergiSorumlusuListesi");
        }

        public ActionResult sorumluSil(int id)
        {
            SergiSorumlulari ss = db.SergiSorumlulari.Where(x => x.sorumluID == id).SingleOrDefault();

            if (ss != null)
            {
                db.SergiSorumlulari.Remove(ss);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        [HttpGet]
        public ActionResult sorumluDuzenle(int id)
        {
            SergiSorumlulari ss = db.SergiSorumlulari.Where(x => x.sorumluID == id).SingleOrDefault();
            
            return View(ss);
        }

        [HttpPost]
        public ActionResult sorumluDuzenle(SergiSorumlulari ss)
        {
            SergiSorumlulari sorumlukisi = db.SergiSorumlulari.Where(x => x.sorumluID == ss.sorumluID).SingleOrDefault();

            sorumlukisi.adi = ss.adi;
            sorumlukisi.mail = ss.mail;
            db.SaveChanges();
            return RedirectToAction("SergiSorumlusuListesi");
        }


        //------------------------------------ Üye Listesi İşlemleri Başlangıç --------------------//

        [HttpGet]
        public ActionResult uyeListesi()
        {
            return View(db.Uye.Where(x=>x.onay==true).ToList());
        }

        public ActionResult uyeSil(int id)
        {
            Uye uye = db.Uye.Where(x => x.uyeID == id).SingleOrDefault();
            if (uye != null)
            {
                uye.onay = false;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

    }
}