using FluentValidation.Attributes;
using Library_Automation.Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Automation.Entities.Model
{
    [Validator(typeof(EmanetKitaplarValidator))]
    public class EmanetKitaplar
    {
        public int Id { get; set; }
        public int  uyeId{ get; set; }
        public int kitapId { get; set; }
        public int KitapSayisi { get; set; }
        public DateTime KitapAldigiTarihi { get; set; }
        public DateTime KitapIadeTarihi { get; set; }
        public Kitaplar Kitaplar { get; set; }
        public Uyeler Uyeler { get; set; }
    }
}
