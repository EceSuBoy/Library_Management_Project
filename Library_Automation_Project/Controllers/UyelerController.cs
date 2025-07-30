using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UyelerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        UyelerDAL uyelerDAL = new UyelerDAL();
        // GET: Uyeler
        public ActionResult Index()
        {
            var model = uyelerDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(Uyeler entity, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim != null && Resim.ContentLength > 0)
                {
                    var image = Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        Resim.SaveAs(path);
                    }
                    entity.Resim = "/images/" + image;
                }
                uyelerDAL.InsertorUpdate(context, entity);
                uyelerDAL.Save(context);
                return RedirectToAction("Index");


            }
            return View(entity);

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = uyelerDAL.GetByFilter(context, x => x.Id == id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Uyeler entity, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                var model = uyelerDAL.GetByFilter(context, x => x.Id == entity.Id);
                entity.Resim = model.Resim;

                if (Resim != null && Resim.ContentLength > 0)
                {
                    var image = Path.GetFileName(Resim.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        Resim.SaveAs(path);
                    }
                    entity.Resim = "/images/" + image;
                }
                uyelerDAL.InsertorUpdate(context, entity);
                uyelerDAL.Save(context);
                return RedirectToAction("Index");


            }
            return View(entity);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            uyelerDAL.Delete(context, x => x.Id == id);
            uyelerDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}