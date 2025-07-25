using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    public class KitapTurleriController : Controller
    {
        // GET: KitapTurleri
        KutuphaneContext context = new KutuphaneContext();
        KitapTurleriDAL KitapTurleriDAL = new KitapTurleriDAL();
        public ActionResult Index(string search)
        {
            var model = KitapTurleriDAL.GetAll(context);
            if (search != null)
            {

                model=KitapTurleriDAL.GetAll(context, x=>x.KitapTuru.Contains(search));
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)
            {

                KitapTurleriDAL.InsertorUpdate(context, kitapTurleri);
                KitapTurleriDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(kitapTurleri);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = KitapTurleriDAL.GetById(context, id);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)
            {

                KitapTurleriDAL.InsertorUpdate(context, kitapTurleri);
                KitapTurleriDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(kitapTurleri);
        }
        public ActionResult Delete(int id)
        {
            KitapTurleriDAL.Delete(context, x=>x.KitapId == id);
            KitapTurleriDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}
