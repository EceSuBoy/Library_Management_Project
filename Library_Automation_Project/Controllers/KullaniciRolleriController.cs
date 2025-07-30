using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Mapping;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    [AllowAnonymous]
    public class KullaniciRolleriController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullaniciRolleriDAL kullaniciRolleriDAL = new KullaniciRolleriDAL();
        // GET: KullaniciRolleri
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("UsernameId is not entered.");
            }
            var model = kullaniciRolleriDAL.GetByFilter(context, x => x.KullaniciId == id, "Kullanicilar");
            ViewBag.KullaniciId = id;
            ViewBag.KullaniciAdi = model.Kullanicilar.KullaniciAdi;
            ViewBag.liste = new SelectList(context.Roller, "Id", "Rol");
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(KullaniciRolleri entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.Roller, "Id", "Rol");
                var model = kullaniciRolleriDAL.GetByFilter(context, x => x.KullaniciId == entity.KullaniciId, "Kullanicilar");
                ViewBag.KullaniciId = entity.Id;
                ViewBag.KullaniciAdi = model.Kullanicilar.KullaniciAdi;

                return View(entity);
            }
            entity.Id = 0;
            kullaniciRolleriDAL.InsertorUpdate(context, entity);
            kullaniciRolleriDAL.Save(context);
            return RedirectToAction("Index2", "Kullanicilar");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("UsernameId is not entered.");
            }
            var model = kullaniciRolleriDAL.GetByFilter(context, x => x.Id == id, "Kullanicilar");
            ViewBag.KullaniciAdi = model.Kullanicilar.KullaniciAdi;
            ViewBag.liste = new SelectList(context.Roller, "Id", "Rol");
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(KullaniciRolleri entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.Roller, "Id", "Rol");
                var model = kullaniciRolleriDAL.GetByFilter(context, x => x.Id == entity.Id, "Kullanicilar");
                ViewBag.KullaniciAdi = model.Kullanicilar.KullaniciAdi;

                return View(entity);
            }
            kullaniciRolleriDAL.InsertorUpdate(context, entity);
            kullaniciRolleriDAL.Save(context);
            return RedirectToAction("Index2", "Kullanicilar");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kullaniciRolleriDAL.Delete(context, x => x.Id == id);
            kullaniciRolleriDAL.Save(context);
            return RedirectToAction("Index2", "Kullanicilar");
        }
    }
}