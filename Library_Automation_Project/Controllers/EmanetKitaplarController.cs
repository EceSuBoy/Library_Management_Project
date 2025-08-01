using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Mapping;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Library_Automation_Project.Controllers
{
    public class EmanetKitaplarController : Controller
    {
        // GET: EmanetKitaplar
        KutuphaneContext context = new KutuphaneContext();
        EmanetKitaplarDAL EmanetKitaplarDAL = new EmanetKitaplarDAL();
        KitaplarDAL kitaplarDAL = new KitaplarDAL();
        KitapHareketleriDAL kitapHareketleriDAL = new KitapHareketleriDAL();
        public ActionResult Index()
        {
            var model = EmanetKitaplarDAL.GetAll(context, x => x.KitapIadeTarihi == null, "Kitaplar", "Uyeler");
            return View(model);
        }

        public ActionResult Yazdir()
        {
            var model = EmanetKitaplarDAL.GetAll(context, x => x.KitapIadeTarihi == null, "Kitaplar", "Uyeler");
            return new Rotativa.ActionAsPdf("EmanetListesi", model)
            {
                FileName = "EmanetKitaplarListesi.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
                CustomSwitches = "--disable-smart-shrinking"

            };
        }

        public ActionResult EmanetListesi()
        {
            var model = EmanetKitaplarDAL.GetAll(context, x => x.KitapIadeTarihi == null, "Kitaplar", "Uyeler");
            return View(model);
        }

        public ActionResult DepositBook()
        {
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DepositBook(EmanetKitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
                ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
                return RedirectToAction("Index");
            }

            var email = User.Identity.Name;
            var modelKullanici = context.Kullanicilar.FirstOrDefault(k => k.Email == email);

            var kitap = context.Kitaplar.FirstOrDefault(k => k.Id == entity.kitapId);
            var uye = context.Uyeler.FirstOrDefault(u => u.Id == entity.uyeId);

            EmanetKitaplarDAL.InsertorUpdate(context, entity);

            if (modelKullanici != null && kitap != null && uye != null)
            {
                var kitapHareket = new KitapHareketleri
                {
                    KullaniciId = modelKullanici.Id,
                    KitapId = kitap.Id,
                    UyeId = uye.Id,
                    Tarih = DateTime.Now,
                    YapilanIslem = $"{modelKullanici.KullaniciAdi} gave {entity.KitapSayisi} book(s) ({kitap.KitapAdi}) to {uye.AdiSoyadi}"
                };

                kitapHareketleriDAL.InsertorUpdate(context, kitapHareket);
            }

            EmanetKitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
            var model = EmanetKitaplarDAL.GetByFilter(context, x => x.Id == id, "Uyeler", "Kitaplar");

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EmanetKitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
                ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
                return RedirectToAction("Index");
            }

            EmanetKitaplarDAL.InsertorUpdate(context, entity);
            EmanetKitaplarDAL.Save(context);


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            EmanetKitaplarDAL.Delete(context, x => x.Id == id);
            EmanetKitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }

        public ActionResult TeslimAl(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var model = EmanetKitaplarDAL.GetByFilter(context, x => x.Id == id, "Kitaplar", "Uyeler");
            if (model == null)
                return HttpNotFound();

            // Set return date
            model.KitapIadeTarihi = DateTime.Now;

            // Update stock
            var kitap = kitaplarDAL.GetByFilter(context, x => x.Id == model.kitapId);
            if (kitap != null)
            {
                kitap.StokAdedi += model.KitapSayisi;
            }

            // Get current user
            var email = User.Identity.Name;
            var kullanici = context.Kullanicilar.FirstOrDefault(k => k.Email == email);

            // Create kitap hareket log
            if (kullanici != null)
            {
                var hareket = new KitapHareketleri
                {
                    KullaniciId = kullanici.Id,
                    KitapId = model.kitapId,
                    UyeId = model.uyeId,
                    Tarih = DateTime.Now,
                    YapilanIslem = $"{model.Uyeler.AdiSoyadi} returned {model.KitapSayisi} books '{kitap.KitapAdi}' to {kullanici.KullaniciAdi}"
                };

                kitapHareketleriDAL.InsertorUpdate(context, hareket);
            }

            EmanetKitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }

    }
}