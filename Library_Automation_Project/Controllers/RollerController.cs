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
    [Authorize(Roles ="Admin")]
    public class RollerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        RollerDAL rollerDAL = new RollerDAL();
        // GET: Roller
        public ActionResult Index()
        {
            var model = rollerDAL.GetAll(context);
            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(Roller entity)
        {
            if(!ModelState.IsValid)
            {
                return View(entity);
            }
            rollerDAL.InsertorUpdate(context, entity);
            rollerDAL.Save(context);
            return RedirectToAction("Index");   
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return HttpNotFound("Id is not entered.");
            }
            var model = rollerDAL.GetByFilter(context, x => x.Id == id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Roller entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            rollerDAL.InsertorUpdate(context, entity);
            rollerDAL.Save(context);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirmed(int id)
        {
            rollerDAL.Delete(context, x=>x.Id == id);
            rollerDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}