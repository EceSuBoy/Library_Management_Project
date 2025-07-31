using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL kitaplarDAL = new KitaplarDAL();
        KitapKayitHareketleriDAL kitapKayitHareketleriDAL = new KitapKayitHareketleriDAL();
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();

        public void KitapKayitHareketleri(int kullaniciId, int kitapId, string yapilanIslem, string aciklama)
        {
            var model = new KitapKayitHareketleri
            {
                Aciklama= aciklama,
                KullaniciId= kullaniciId,
                KitapId= kitapId,
                YapilanIslem= yapilanIslem,
                Tarih=DateTime.Now,
            };
            kitapKayitHareketleriDAL.InsertorUpdate(context, model);
            kitapKayitHareketleriDAL.Save(context);
        }
     
        public ActionResult Index()
        {
            var model = kitaplarDAL.GetAll(context, null, "KitapTurleri");
            return View(model);
        }
        public ActionResult Add() 
        {

            ViewBag.Liste = new SelectList(context.KitapTurleri, "KitapId", "KitapTuru");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Kitaplar entity)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Liste = new SelectList(context.KitapTurleri, "KitapId", "KitapTuru");
                return View(entity);
            }
            kitaplarDAL.InsertorUpdate(context, entity);
            kitaplarDAL.Save(context);

            int kitapId= context.Kitaplar.Max(x=>x.Id);
            var userName=User.Identity.Name;
            var modelKullanici = kullanicilarDAL.GetByFilter(context, x=>x.Email==userName);
            int kullaniciId = modelKullanici.Id;

            string yapilanIslem = $"{modelKullanici.KullaniciAdi} added a new book: '{entity.KitapAdi}' by '{entity.Yazari}'.";
            string aciklama = "Adding book operations.";

            KitapKayitHareketleri(kullaniciId, kitapId, yapilanIslem, aciklama);


            return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            ViewBag.Liste = new SelectList(context.KitapTurleri, "KitapId", "KitapTuru");
            var model = kitaplarDAL.GetByFilter(context, x => x.Id == id, "KitapTurleri");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Liste = new SelectList(context.KitapTurleri, "KitapId", "KitapTuru");
                return View(entity);
            }

            kitaplarDAL.InsertorUpdate(context, entity);
            kitaplarDAL.Save(context);

            int kitapId = entity.Id;
            var userName = User.Identity.Name;
            var modelKullanici = kullanicilarDAL.GetByFilter(context, x => x.Email == userName);
            int kullaniciId = modelKullanici.Id;

            string yapilanIslem = $"{modelKullanici.KullaniciAdi} edited the book: '{entity.KitapAdi}' by '{entity.Yazari}'.";
            string aciklama = "Editing book operations.";

            KitapKayitHareketleri(kullaniciId, kitapId, yapilanIslem, aciklama);

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            var model = kitaplarDAL.GetByFilter(context, x=>x.Id == id, "KitapTurleri");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var kitap = kitaplarDAL.GetByFilter(context, x => x.Id == id); // Kitap bilgilerini silmeden önce al
            if (kitap == null)
            {
                return HttpNotFound();
            }

            var userName = User.Identity.Name;
            var modelKullanici = kullanicilarDAL.GetByFilter(context, x => x.Email == userName);
            int kullaniciId = modelKullanici.Id;

            string yapilanIslem = $"{modelKullanici.KullaniciAdi} deleted the book: '{kitap.KitapAdi}' by '{kitap.Yazari}'.";
            string aciklama = "Deleting book operations.";

            // Önce logu kaydet
            KitapKayitHareketleri(kullaniciId, kitap.Id, yapilanIslem, aciklama);

            // Sonra sil
            kitaplarDAL.Delete(context, x => x.Id == id);
            kitaplarDAL.Save(context);

            return RedirectToAction("Index");
        }


    }
}