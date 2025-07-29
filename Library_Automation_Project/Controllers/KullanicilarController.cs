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
        public ActionResult SignUp()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SignUp(Kullanicilar entity, string sifreTekrar, bool kabul)
        {
            if (!ModelState.IsValid)
            {
                return View(entity); // if model is invalid, just return the view with validation errors
            }

            // now check password
            if (entity.Sifre != sifreTekrar)
            {
                ViewBag.sifreError = "Passwords doesn't match.";
                return View(entity);
            }

            if (!kabul)
            {
                ViewBag.kabulError = "Please confirm that you agree the terms.";
                return View(entity);
            }

            // everything is valid
            entity.KayitTarihi = DateTime.Now;
            kullanicilarDAL.InsertorUpdate(context, entity);
            kullanicilarDAL.Save(context);
            return RedirectToAction("Login");
        }
    }
}