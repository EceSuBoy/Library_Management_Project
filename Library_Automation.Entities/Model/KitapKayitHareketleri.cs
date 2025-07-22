using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    public class KitapKayitHareketleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int KitapId { get; set; }
        public string YapilanIslem { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
