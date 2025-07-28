using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        KutuphaneContext context = new KutuphaneContext();
        DuyurularDAL duyurularDAL = new DuyurularDAL();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DuyuruList()
        {
            var model = duyurularDAL.GetAll(context);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddAnnouncement(Duyurular entity)
        {
            if (ModelState.IsValid)
            {
                duyurularDAL.InsertorUpdate(context, entity);
                duyurularDAL.Save(context);
                return Json(new { success = true, message = "Completed Successfully!" });
            }
            var errors = ModelState.ToDictionary(
                x => x.Key,
                x => x.Value.Errors.Select(a => a.ErrorMessage).ToArray());
            return Json(new {success=false, errors}, JsonRequestBehavior.AllowGet);
        }
    }
}