using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    public class IstatistiklerController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        KullaniciHareketleriDAL KullaniciHareketleriDAL = new KullaniciHareketleriDAL();
        KullanicilarDAL KullanicilarDAL = new KullanicilarDAL();    
        UyelerDAL UyelerDAL = new UyelerDAL();
        // GET: Istatistikler
        public ActionResult Index()
        {
            UyelerDAL.UyeKitapIslemleri();
            ViewBag.EnCokUye = UyelerDAL.EnCokUye;
            ViewBag.EnAzUye = UyelerDAL.EnAzUye;
            ViewBag.EnCokSayi = UyelerDAL.EnCokSayi;
            ViewBag.EnAzSayi = UyelerDAL.EnAzSayi;

            ViewBag.UyeKitapModel = UyelerDAL.UyeKitapModel;

            //Kullanici Sayisi
            var KullaniciSayisiModel = KullanicilarDAL.GetAll(context);
            ViewBag.Count=KullaniciSayisiModel.Count;

            //En cok giris yapan kullanici adi ve giris sayisi
            var model = KullaniciHareketleriDAL.KullaniciGirisSayilari();
            ViewBag.KullaniciAdi = model.kullaniciAdi;
            ViewBag.GirisSayisi = model.GirisSayisi;

            //KullaniciHareketleri
            KullaniciHareketleriDAL.KullaniciHareketleriGozlemleme();
            ViewBag.AylikVeriler = KullaniciHareketleriDAL.AylikVeriler;
            ViewBag.ToplamKHGSayisi = KullaniciHareketleriDAL.ToplamKHGSayisi;
            ViewBag.AltiAyToplamKHGSayisi = KullaniciHareketleriDAL.AltiAyToplamKHGSayisi;
            return View();
        }
    }
}