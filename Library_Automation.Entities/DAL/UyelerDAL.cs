using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using Library_Automation.Entities.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.DAL
{
    public class UyelerDAL : GenericRepository<KutuphaneContext, Uyeler>
    {
        KutuphaneContext context = new KutuphaneContext();
        public string EnCokUye;
        public string EnAzUye;
        public int EnCokSayi;
        public int EnAzSayi;

        public object UyeKitapModel;

        public object UyeKitapIslemleri()
        {
            EnCokUye = context.Uyeler.OrderByDescending(x => x.OkunanKitapSayisi).FirstOrDefault().AdiSoyadi;
            EnAzUye = context.Uyeler.OrderBy(x => x.OkunanKitapSayisi).FirstOrDefault().AdiSoyadi;

            EnCokSayi = context.Uyeler.OrderByDescending(x => x.OkunanKitapSayisi).FirstOrDefault().OkunanKitapSayisi;
            EnAzSayi = context.Uyeler.Min(x => x.OkunanKitapSayisi);
            double ort = context.Uyeler.Average(x => x.OkunanKitapSayisi);

            double ToplamKitap = context.Uyeler.Sum(x => x.OkunanKitapSayisi);

            UyeKitapModel = context.Uyeler
                .OrderByDescending(x => x.OkunanKitapSayisi)
                .Take(3)
                .Select(x => new
                {
                    x.AdiSoyadi,
                    x.OkunanKitapSayisi,
                    Yuzde = (ToplamKitap == 0) ? 0 : ((double)x.OkunanKitapSayisi / ToplamKitap) * 100
                })
                .ToList();

            return UyeKitapModel;
        }
    }
}
