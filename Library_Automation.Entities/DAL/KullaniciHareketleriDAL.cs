using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using Library_Automation.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.DAL
{
    public class KullaniciHareketleriDAL: GenericRepository<KutuphaneContext, KullaniciHareketleri>
    {
        KutuphaneContext context = new KutuphaneContext();
        public object AylikVeriler;
        public object ToplamKHGSayisi;
        public object AltiAyToplamKHGSayisi;
        public (string kullaniciAdi, int GirisSayisi) KullaniciGirisSayilari()
        {
            var result=context.Set<KullaniciHareketleri>().GroupBy(x=> new {x.KullaniciId, x.Kullanicilar.KullaniciAdi}).
                Select(y=> new
                {
                    KullaniciAdi=y.Key.KullaniciAdi,
                    GirisSayisi=y.Count()

                }).OrderByDescending(w=>w.GirisSayisi).FirstOrDefault();
            if(result != null)
            {
                return (result.KullaniciAdi, result.GirisSayisi);
            }


            return (null, 0); //Varsayilan deger
        }
        public object KullaniciHareketleriGozlemleme()
        {
            DateTime altiAyOnce = DateTime.Now.AddMonths(-6);
            AylikVeriler = context.KullaniciHareketleri.Where(x => x.Tarih >= altiAyOnce).
                GroupBy(a => new
                {
                    Ay = a.Tarih.Month,
                    Yil = a.Tarih.Year,

                }).Select(b => new
                {
                    Ay = b.Key.Ay,
                    Yil = b.Key.Yil,
                    HareketSayi = b.Count()

                }).OrderBy(a => a.Yil).ThenBy(y => y.Ay).ToList();
            ToplamKHGSayisi = context.KullaniciHareketleri.Count();
            AltiAyToplamKHGSayisi = context.KullaniciHareketleri.Count(x => x.Tarih >= altiAyOnce);

            return AylikVeriler;
        }
    }
}
