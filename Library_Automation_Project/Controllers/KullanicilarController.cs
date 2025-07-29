using Library_Automation.Entities.Model;
using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library_Automation_Project.Controllers
{
    public class KullanicilarController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
        // GET: Kullanicilar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar entity)
        {
            var model = kullanicilarDAL.GetByFilter(context, x => x.Email== entity.Email && x.Sifre == entity.Sifre); 
            if(model!=null)
            {
                FormsAuthentication.SetAuthCookie(model.KullaniciAdi, false);
                if(User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                return RedirectToAction("Index", "KitapTurleri");
            }
            ViewBag.error = "Username or Password is incorrect";
            return View();
        }
    }
}