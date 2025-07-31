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
    public class UyelerDAL: GenericRepository<KutuphaneContext, Uyeler>
    {
        KutuphaneContext context = new KutuphaneContext();
        public string EnCokUye;
        public string EnAzUye;
        public int EnCokSayi;
        public int EnAzSayi;
        public void UyeKitapIslemleri()
        {
            EnCokUye=context.Uyeler.OrderByDescending(x=>x.OkunanKitapSayisi).FirstOrDefault().AdiSoyadi;
            EnAzUye=context.Uyeler.OrderBy(x=>x.OkunanKitapSayisi).FirstOrDefault().AdiSoyadi;

            EnCokSayi=context.Uyeler.OrderByDescending(x=>x.OkunanKitapSayisi).FirstOrDefault().OkunanKitapSayisi;
            EnAzSayi = context.Uyeler.Min(x => x.OkunanKitapSayisi);
            double ort = context.Uyeler.Average(x => x.OkunanKitapSayisi);
        }
    }
}
