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
    }
}
