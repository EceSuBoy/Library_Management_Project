using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(KullaniciRolleriValidator))]
    public class KullaniciRolleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int RolId { get; set; }
        public Kullanicilar Kullanicilar { get; set; }
        public Roller Roller { get; set; }
    }
}
