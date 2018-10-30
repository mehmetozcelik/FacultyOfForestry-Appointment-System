using OrmanFakultesi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrmanFakultesi.Controllers
{
    public class SergiController : Controller
    {
        // GET: Sergi
        ofContext db = new ofContext();

        //-------------------Sergi İşlemleri -------------------------------------//

        public ActionResult Listesi()
        {
            return View(db.Sergi.ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        public ActionResult Ekle(Sergi s,HttpPostedFileBase file)
        {
            if (file !=null)
            {
                Image img = Image.FromStream(file.InputStream);
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                img.Save(Server.MapPath("/Content/Admin/img/Sergi/anasergi/" + filename));

                s.resimYolu = filename;
                db.Sergi.Add(s);
                db.SaveChanges();
                return RedirectToAction("Listesi");
            }
            else
            {
                ViewBag.sergihata = "Bir hata oluştu. Tekrar Deneyiniz.";
                return View();
            }
        }

        public ActionResult Sil(int id)
        {
            Sergi s = db.Sergi.Where(x => x.sergiID == id).SingleOrDefault();
            if (s!=null)
            {
                db.Sergi.Remove(s);
                db.SaveChanges();
                return Json(true);
            }

            return Json(false);
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            return View(db.Sergi.Where(x => x.sergiID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Duzenle(Sergi s , HttpPostedFileBase file)
        {
            Sergi ss = db.Sergi.Where(x => x.sergiID == s.sergiID).FirstOrDefault();
            if (file !=null)
            {
                Image img = Image.FromStream(file.InputStream);
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                img.Save(Server.MapPath("/Content/Admin/img/Sergi/anasergi/" + filename));


                var fullPath = Server.MapPath("/Content/Admin/img/Sergi/anasergi/" + ss.resimYolu); // eski resim silindi.
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                ss.resimYolu = filename;
            }

            ss.adi = s.adi;
            ss.aciklama = s.aciklama;
            ss.kisaAciklama = s.kisaAciklama;
            db.SaveChanges();

            return RedirectToAction("Listesi");
        }


        //------------------- Alt Sergi İşlemleri -------------------------------------//

        [HttpGet]
        public  ActionResult altSergiListesi()
        {
            return View(db.AltSergi.ToList());
        }

        [HttpGet]
        public ActionResult altSergiEkle()
        {
            var sergi = db.Sergi.ToList();
            var sergiler = new SelectList(sergi, "sergiID", "adi");

            var bolum = db.BolumTanimi.ToList();
            ViewBag.bolumler = new SelectList(bolum,"bolumID", "adi");
            var sorumlular= db.SergiSorumlulari.ToList();
            ViewBag.sorumlu = new MultiSelectList(sorumlular,"sorumluID","adi");

            return View(sergiler);
        }

        [HttpPost]
        public ActionResult altSergiEkle(int[] sorumluID)
        {
   
            return View();
        }

    }
}