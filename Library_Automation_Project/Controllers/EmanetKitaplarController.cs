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
    [AllowAnonymous]
    public class EmanetKitaplarController : Controller
    {
        // GET: EmanetKitaplar
        KutuphaneContext context = new KutuphaneContext();
        EmanetKitaplarDAL EmanetKitaplarDAL= new EmanetKitaplarDAL();
        KitaplarDAL kitaplarDAL= new KitaplarDAL();
        public ActionResult Index()
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

            EmanetKitaplarDAL.InsertorUpdate(context, entity);
            EmanetKitaplarDAL.Save(context);

            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
            var model=EmanetKitaplarDAL.GetByFilter(context, x=>x.Id == id, "Uyeler", "Kitaplar");

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
            EmanetKitaplarDAL.Delete(context, x=>x.Id == id);
            EmanetKitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}