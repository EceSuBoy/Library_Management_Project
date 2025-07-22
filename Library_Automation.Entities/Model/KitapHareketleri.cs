using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    public class KitapHareketleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int UyeId { get; set; }
        public int KitapId { get; set; }
        public string YapilanIsmlem { get; set; }
        public DateTime Tarih { get; set; }
    }
}
