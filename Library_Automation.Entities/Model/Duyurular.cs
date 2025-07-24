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
    [Validator(typeof(DuyurularValidator))]
    public class Duyurular
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Baslik { get; set; }
        [Display(Name = "Announcement")]
        public string Duyuru { get; set; }
        [Display(Name = "Description")]
        public string Aciklama { get; set; }
        [Display(Name = "Date")]
        public DateTime Tarih { get; set; }
    }
}
