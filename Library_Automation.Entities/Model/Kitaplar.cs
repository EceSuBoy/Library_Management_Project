using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(KitaplarValidator))]
    public class Kitaplar
    {
        public int Id { get; set; }
        public string BarkodNo { get; set; }
        public int KitapTuruId { get; set; }
        public string KitapAdi { get; set; }
        public string Yazari { get; set; }
        public string YayinEvi { get; set; }
        public int StokAdedi { get; set; }
        public int SayfaSayisi { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklemeTarihi { get; set; } = DateTime.Now;
        public DateTime GuncellemeTarihi { get; set; } = DateTime.Now;
        public bool SilindiMi { get; set; }
        public KitapTurleri KitapTurleri { get; set; } //Tekil Adlandirma
        public List<EmanetKitaplar> EmanetKitaplar { get; set; }
        public List<KitapHareketleri> KitapHareketleri { get; set; }
        public List<KitapKayitHareketleri> KitapKayitHareketleri { get; set; }
    }
}
