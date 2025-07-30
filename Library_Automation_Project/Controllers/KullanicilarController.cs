using Library_Automation.Entities.Model;
using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using Library_Automation.Entities.Model.ViewModel;

namespace Library_Automation_Project.Controllers
{
    [Authorize(Roles="Admin, Moderator")]
    public class KullanicilarController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
        KullaniciRolleriDAL KullaniciRolleriDAL = new KullaniciRolleriDAL();
        RollerDAL rollerDAL = new RollerDAL();
        // GET: Kullanicilar
        public ActionResult Index()
        {
            var model = kullanicilarDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            kullanicilarDAL.InsertorUpdate(context, entity);
            kullanicilarDAL.Save(context);
            return RedirectToAction("Index2"); 
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Id value is not entered.");
            }
            var model = kullanicilarDAL.GetById(context, id);
            return View(model);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Edit(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            kullanicilarDAL.InsertorUpdate(context, entity);
            kullanicilarDAL.Save(context);
            return RedirectToAction("Index2");
        }

        public ActionResult Delete(int? id)
        {
            kullanicilarDAL.Delete(context, x=> x.Id == id);
            kullanicilarDAL.Save(context);
            return RedirectToAction("Index2");
        }



        public ActionResult Index2()
        {
            var kullanicilar = kullanicilarDAL.GetAll(context, tbl: "KullaniciRolleri");
            var roller = rollerDAL.GetAll(context);
            return View(new KullaniciRolViewModel { Kullanicilar=kullanicilar, Roller=roller});
        }

        public ActionResult kRolleri(int id)
        {
            var model = KullaniciRolleriDAL.GetAll(context, x => x.KullaniciId == id, "Roller");
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanicilar entity)
        {
            var model = kullanicilarDAL.GetByFilter(context, x => x.Email == entity.Email && x.Sifre == entity.Sifre);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(entity.Email, false);
                if (User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }
                return RedirectToAction("Index", "KitapTurleri");
            }
            ViewBag.error = "Username or Password is incorrect";
            return View();
        }
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
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
        [AllowAnonymous]

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ForgotPassword(Kullanicilar entity)
        {
            var model = kullanicilarDAL.GetByFilter(context, x => x.Email == entity.Email);
            if (model != null)
            {
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 8);
                kullanicilarDAL.Save(context);
                SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("zy27448@gmail.com", "Şifre sıfırlama");
                mail.To.Add(model.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Değiştirme İsteği";
                mail.Body += "Merhaba " + model.AdiSoyadi + "<br/> Kullanıcı Adınız=" + model.KullaniciAdi + "<br/> Şifreniz=" + model.Sifre;
                NetworkCredential net = new NetworkCredential("zy27448@gmail.com", "adwfawwfa123421");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Login");
            }
            else if (model == null && entity.Email != null)
            {
                ViewBag.hata = "Böyle bir e-mail adresi bulunamadı.";
                return View();
            }
            return View();
        }

    }
}