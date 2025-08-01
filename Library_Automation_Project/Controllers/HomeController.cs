using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Automation_Project.ViewModels;
using System.Web.Mvc;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.DAL;

namespace Library_Automation_Project.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        IletisimDAL IletisimDAL= new IletisimDAL();
        public ActionResult Index()
        {
            var lastFiveBooks = context.Kitaplar
       .OrderByDescending(b => b.EklemeTarihi)
       .Take(5)
       .ToList();

            var popularBooks = context.Kitaplar
                .OrderByDescending(b => b.StokAdedi)  // or any other popularity metric
                .Take(3)
                .ToList();

            var model = new HomeViewModel
            {
                LastFiveBooks = lastFiveBooks,
                PopularBooks = popularBooks
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Iletisim model)
        {
            if(ModelState.IsValid)
            {
                model.Tarih=DateTime.Now;
                IletisimDAL.InsertorUpdate(context, model);
                IletisimDAL.Save(context);
                TempData["Message"] = "Message was sent successfully.";
                return RedirectToAction("Contact");
            }

            return View(model);
        }




        public ActionResult AdminIndex()
        {
            return View();
        }

    }
}