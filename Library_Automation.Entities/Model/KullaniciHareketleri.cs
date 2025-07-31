using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(KullaniciHareketleriValidator))]
    public class KullaniciHareketleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public int IslemYapan { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
    }
}
