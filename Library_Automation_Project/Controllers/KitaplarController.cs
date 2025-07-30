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
            kitaplarDAL.Delete(context, x => x.Id == id);
            kitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }

    }
}