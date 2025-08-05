using ClosedXML.Excel;
using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model.Contacts;
using System;
using System.Collections.Generic;
using System.IO;
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
        EmanetKitaplarDAL emanetKitaplarDAL = new EmanetKitaplarDAL();
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
            ViewBag.Count = KullaniciSayisiModel.Count;

            var UyeSayisiModel = UyelerDAL.GetAll(context);
            ViewBag.UyeCount = UyeSayisiModel.Count;    

            //En cok giris yapan kullanici adi ve giris sayisi
            var model = KullaniciHareketleriDAL.KullaniciGirisSayilari();
            ViewBag.KullaniciAdi = model.kullaniciAdi;
            ViewBag.GirisSayisi = model.GirisSayisi;

            //KullaniciHareketleri
            KullaniciHareketleriDAL.KullaniciHareketleriGozlemleme();
            ViewBag.AylikVeriler = KullaniciHareketleriDAL.AylikVeriler;
            ViewBag.ToplamKHGSayisi = KullaniciHareketleriDAL.ToplamKHGSayisi;
            ViewBag.AltiAyToplamKHGSayisi = KullaniciHareketleriDAL.AltiAyToplamKHGSayisi;

            // Kitap Türü Sayısı
            ViewBag.KitapTuruSayisi = context.KitapTurleri.Count();

            // Her Kitap Türünden Kaç Tane Var
            var kitapTurGruplari = context.Kitaplar
                .GroupBy(k => k.KitapTurleri.KitapTuru)
                .Select(g => new { KitapTuru = g.Key, Adet = g.Count() })
                .ToList();
            ViewBag.KitapTurGruplari = kitapTurGruplari;

            // Stoku En Fazla Olan Kitap
            var enFazlaStok = context.Kitaplar
                .OrderByDescending(k => k.StokAdedi)
                .FirstOrDefault();
            ViewBag.EnFazlaStokKitap = enFazlaStok;

            // Stoku En Az Olan Kitap (0’dan büyük)
            var enAzStok = context.Kitaplar
                .Where(k => k.StokAdedi > 0)
                .OrderBy(k => k.StokAdedi)
                .FirstOrDefault();
            ViewBag.EnAzStokKitap = enAzStok;


            // En son eklenen kitap
            var latestBook = context.Kitaplar
                .Where(k => !k.SilindiMi)
                .OrderByDescending(k => k.Id)
                .FirstOrDefault();
            ViewBag.LatestBook = latestBook;

            // En çok okunan kitapların Id'leri
            var mostReadBookIds = context.KitapHareketleri
                .GroupBy(h => h.KitapId)
                .Select(g => new
                {
                    KitapId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .Take(3)
                .Select(g => g.KitapId)
                .ToList();

            // En çok okunan kitaplar
            // Silinmemiş kitaplar arasında en çok okunan 3 kitap
            var topBooks = context.KitapHareketleri
                .Where(h => !h.Kitaplar.SilindiMi)
                .GroupBy(h => h.KitapId)
                .Select(g => new
                {
                    Kitap = g.FirstOrDefault().Kitaplar,
                    OkunmaSayisi = g.Count()
                })
                .OrderByDescending(g => g.OkunmaSayisi)
                .Take(3)
                .Select(g => g.Kitap)
                .ToList();

            ViewBag.TopBooks = topBooks;




            return View();
        }

        public ActionResult ExceleAktar()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Borrowed Books");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Member Name";
                worksheet.Cell(1, 3).Value = "Book Name";
                worksheet.Cell(1, 3).Value = "Number of Books";
                worksheet.Cell(1, 5).Value = "Date Borrowed";

                var model = emanetKitaplarDAL.GetAll(context, x => x.KitapIadeTarihi == null, "Uyeler", "Kitaplar");

                int row = 2;
                foreach (var item in model)
                {
                    worksheet.Cell(row, 1).Value = item.Id;
                    worksheet.Cell(row, 2).Value = item.Uyeler.AdiSoyadi;
                    worksheet.Cell(row, 3).Value = item.Kitaplar.KitapAdi;
                    worksheet.Cell(row, 4).Value = item.KitapSayisi;
                    worksheet.Cell(row, 5).Value = item.KitapAldigiTarihi;
                    row++;
                }
                using (var stream = new MemoryStream()) //verileri ramde sakliyoruz
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                    return File(stream.ToArray(), "application/vnd.openXmlformats-officedocument.spreadsheetml.Sheet", "EmanetKitaplarSeri.xlsx");
                }


            }
        }
    }
}